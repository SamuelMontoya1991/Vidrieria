using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.Buscadores;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Compras
{
    public partial class NuevaCompra : Form, IFormularioConUsuario, IFormularioConTema
    {
        private ConexionDB BD = new ConexionDB();
        private Tema temaActual;
        private Usuario? usuario;

        TextBox autoCompleteBox = new TextBox();
        AutoCompleteStringCollection autoCompleteData = new AutoCompleteStringCollection();
        public NuevaCompra()
        {
            InitializeComponent();
            formatearColumnasNumericas();

            autoCompleteBox.Visible = false;
            autoCompleteBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            autoCompleteBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            autoCompleteBox.AutoCompleteCustomSource = autoCompleteData;

            autoCompleteBox.Leave += (s, e) => autoCompleteBox.Visible = false;
            autoCompleteBox.KeyDown += autoCompleteBox_KeyDown;
            autoCompleteBox.TextChanged -= AutoCompleteBox_TextChanged;
            autoCompleteBox.TextChanged += AutoCompleteBox_TextChanged;

        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
            tblMateriales.AllowUserToAddRows = false;
            tblMateriales.Rows.Add();
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void cargarProveedores()
        {
            DataTable tabla = BD.LlenarTabla("SELECT  NombreProveedor FROM sis_proveedores");
            if (tabla != null && tabla.Rows.Count > 0)
            {
                tblProveedor.DataSource = tabla;
            }
            else
            {
                MessageBox.Show("No se encontraron proveedores.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void formatearColumnasNumericas()
        {
            // Asegurar que las columnas de tipo decimal estén bien formateadas
            if (tblMateriales.Columns["precioU"] != null)
            {
                tblMateriales.Columns["precioU"].DefaultCellStyle.Format = "N2";
                tblMateriales.Columns["precioU"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }

            if (tblMateriales.Columns["subtotal"] != null)
            {
                tblMateriales.Columns["subtotal"].DefaultCellStyle.Format = "N2";
                tblMateriales.Columns["subtotal"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            }
        }
        private void actualizarTotales()
        {
            int totalCantidad = 0;
            decimal totalSubtotal = 0m;

            foreach (DataGridViewRow fila in tblMateriales.Rows)
            {
                if (fila.IsNewRow) continue;

                int cantidad = 0;
                decimal subtotal = 0m;

                if (fila.Cells["cantidad"].Value != null)
                    int.TryParse(fila.Cells["cantidad"].Value.ToString(), out cantidad);

                if (fila.Cells["subtotal"].Value != null)
                    decimal.TryParse(fila.Cells["subtotal"].Value.ToString(), out subtotal);

                totalCantidad += cantidad;
                totalSubtotal += subtotal;
            }

            txtTotalCantidad.Text = totalCantidad.ToString();
            txtTotal.Text = totalSubtotal.ToString("N2");
        }

        private void txtCodigoProveedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string consulta = "SELECT NombreProveedor FROM sis_proveedores WHERE Id_Proveedor = " + txtCodigoProveedor.Text.Trim() + "";
                string nombreCliente = BD.devolverUnValor(consulta);
                if (!string.IsNullOrEmpty(nombreCliente))
                {
                    txtNombreProveedor.Text = nombreCliente;
                    tblMateriales.Focus();
                    tblMateriales.CurrentCell = tblMateriales.Rows[0].Cells["id_material"];
                    tblMateriales.BeginEdit(true);

                }
                else
                {
                    MessageBox.Show("El proveedor no existe. Por favor, verifique el código ingresado.", "Proveedor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoProveedor.Clear();
                    txtNombreProveedor.Clear();
                }
            }
        }

        private void txtNombreProveedor_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreProveedor.Text.Equals(""))
            {
                cargarProveedores();
            }
            else
            {

                DataTable tabla = BD.LlenarTabla("SELECT NombreProveedor FROM sis_proveedores WHERE NombreProveedor LIKE '%" + txtNombreProveedor.Text.Trim() + "%'");
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    tblProveedor.DataSource = tabla;
                }
                else
                {
                    MessageBox.Show("No se encontraron proveedores con ese nombre.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    tblProveedor.DataSource = null; // Limpiar la tabla si no hay resultados
                }
            }
        }

        private void tblMateriales_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            var col = tblMateriales.Columns[e.ColumnIndex].Name;
            var fila = tblMateriales.Rows[e.RowIndex];

            if (col == "id_material" || col == "descripcion")
            {
                string valor = fila.Cells[col].Value?.ToString()?.Trim() ?? "";
                if (!string.IsNullOrEmpty(valor))
                {
                    DataRow? material = BD.BuscarMaterial(valor, col);
                    if (material != null)
                    {
                        
                        foreach (DataGridViewRow row in tblMateriales.Rows)
                        {
                            if (row.Index != e.RowIndex &&
                                row.Cells["id_material"].Value?.ToString() == material["id_material"].ToString())
                            {
                                
                                int cantidadExistente = Convert.ToInt32(row.Cells["cantidad"].Value ?? 0);
                                int nuevaCantidad = Convert.ToInt32(fila.Cells["cantidad"].Value ?? 1);
                                row.Cells["cantidad"].Value = cantidadExistente + nuevaCantidad;

                                
                                tblMateriales.Rows.RemoveAt(e.RowIndex);
                                return;
                            }
                        }

                        
                        fila.Cells["id_material"].Value = material["id_material"];
                        fila.Cells["descripcion"].Value = material["descripcion"];
                        fila.Cells["precioU"].Value = material["precio"];

                        
                        if (e.RowIndex == tblMateriales.Rows.Count - 1 && e.ColumnIndex == tblMateriales.ColumnCount-2)
                            tblMateriales.Rows.Add();
                    }
                    else
                    {
                        MessageBox.Show("Material no encontrado.");
                    }
                    actualizarTotales();
                    if (col == "precioU" || col == "subtotal")
                    {
                        if (decimal.TryParse(fila.Cells[col].Value?.ToString(), out decimal valor2))
                        {
                            fila.Cells[col].Value = valor2.ToString("N2"); // formato con dos decimales
                        }
                    }
                }
            }

            // Si se edita una de las columnas clave, recalcular valores relacionados
            string nombreColumna = tblMateriales.Columns[e.ColumnIndex].Name;

            if (nombreColumna == "cantidad" || nombreColumna == "precioU" || nombreColumna == "subtotal")
            {
                
                if (fila.IsNewRow) return;

                decimal precio = Convert.ToDecimal(fila.Cells["precioU"].Value ?? 0);
                decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value ?? 0);
                int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value ?? 0);

                if (cantidad <= 0)
                {
                    fila.Cells["subtotal"].Value = 0;
                    fila.Cells["precioU"].Value = 0;
                    return;
                }

                switch (nombreColumna)
                {
                    case "cantidad":
                    case "precioU":
                        fila.Cells["subtotal"].Value = cantidad * precio;
                        break;

                    case "subtotal":
                        fila.Cells["precioU"].Value = subtotal / cantidad;
                        break;
                }
            }

        }

        private void tblMateriales_KeyDown(object sender, KeyEventArgs e)
        {
            if (tblMateriales.EditingControl is TextBox tb && tb.Focused && autoCompleteBox.Visible)
            {
                // Si el TextBox de autocompletar está activo, no hacer nada
                return;
            }

            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;

                int col = tblMateriales.CurrentCell.ColumnIndex;
                int row = tblMateriales.CurrentCell.RowIndex;
                int totalCols = tblMateriales.ColumnCount;

                // 🆕 NUEVA LÓGICA DE SUBTOTAL
                var currentCell = tblMateriales.CurrentCell;
                var fila = tblMateriales.Rows[row];
                string nombreCol = tblMateriales.Columns[col].Name;

                int cantidad = Convert.ToInt32(fila.Cells["cantidad"].Value ?? 0);

                if (nombreCol == "precioU")
                {
                    decimal precio = Convert.ToDecimal(fila.Cells["precioU"].Value ?? 0);
                    fila.Cells["subtotal"].Value = cantidad * precio;
                }
                else if (nombreCol == "subtotal")
                {
                    decimal subtotal = Convert.ToDecimal(fila.Cells["subtotal"].Value ?? 0);
                    if (cantidad > 0)
                    {
                        fila.Cells["precioU"].Value = subtotal / cantidad;
                    }
                }

                
                if (col == totalCols - 2 || col == totalCols -1) // penúltima columna o ultima
                {
                    var idMaterial = fila.Cells["id_material"].Value?.ToString();
                    var descripcion = fila.Cells["descripcion"].Value?.ToString();

                    bool filaLlena = !string.IsNullOrWhiteSpace(idMaterial) && !string.IsNullOrWhiteSpace(descripcion);

                    if (filaLlena && row == tblMateriales.Rows.Count - 1)
                    {
                        tblMateriales.Rows.Add();
                    }

                    if (row + 1 < tblMateriales.Rows.Count)
                    {
                        tblMateriales.CurrentCell = tblMateriales.Rows[row + 1].Cells[0];
                    }
                }
                else
                {
                    if (col + 1 < tblMateriales.ColumnCount)
                    {
                        tblMateriales.CurrentCell = tblMateriales.Rows[row].Cells[col + 1];
                    }
                }
                actualizarTotales();
                if (nombreCol == "precioU" || nombreCol == "subtotal")
                {
                    if (decimal.TryParse(fila.Cells[nombreCol].Value?.ToString(), out decimal valor))
                    {
                        fila.Cells[nombreCol].Value = valor.ToString("N2"); // formato con dos decimales
                    }
                }
            }

            if (e.KeyCode == Keys.Delete)
            {
                e.Handled = true; 

                if (tblMateriales.CurrentRow != null && !tblMateriales.CurrentRow.IsNewRow)
                {
                    var filaSeleccionada = tblMateriales.CurrentRow;
                    DialogResult dr = MessageBox.Show(
                        "¿Está seguro de que desea eliminar la fila seleccionada?",
                        "Confirmar eliminación",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Warning);

                    if (dr == DialogResult.Yes)
                    {
                        tblMateriales.Rows.Remove(filaSeleccionada);
                    }
                }
                else
                {
                    MessageBox.Show("No hay fila seleccionada para eliminar.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        private void tblMateriales_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            int col = tblMateriales.CurrentCell.ColumnIndex;
            string colName = tblMateriales.Columns[col].Name;

            if (colName == "descripcion" && e.Control is TextBox tb)
            {
                tb.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                tb.AutoCompleteSource = AutoCompleteSource.CustomSource;

                autoCompleteData.Clear();
                DataTable tabla = BD.LlenarTabla("SELECT descripcion FROM vwmateriales");
                foreach (DataRow row in tabla.Rows)
                {
                    autoCompleteData.Add(row["descripcion"].ToString());
                }
                tb.AutoCompleteCustomSource = autoCompleteData;
            }
            else if (e.Control is TextBox teb)
            {
                teb.AutoCompleteMode = AutoCompleteMode.None;
                teb.AutoCompleteSource = AutoCompleteSource.None;
            }

        }
        private void AutoCompleteBox_TextChanged(object sender, EventArgs e)
        {
            string texto = autoCompleteBox.Text.Trim();
            if (!string.IsNullOrEmpty(texto))
            {
                autoCompleteData.Clear();
                DataTable tabla = BD.LlenarTabla("SELECT descripcion FROM vwmateriales WHERE descripcion LIKE '%" + texto + "%'");
                if (tabla != null && tabla.Rows.Count > 0)
                {
                    foreach (DataRow row in tabla.Rows)
                    {
                        autoCompleteData.Add(row["descripcion"].ToString());
                    }
                }
            }
            else
            {
                autoCompleteData.Clear();
            }
        }
        private void autoCompleteBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int col = tblMateriales.CurrentCell.ColumnIndex;
                int row = tblMateriales.CurrentCell.RowIndex;

                tblMateriales.Rows[row].Cells[col].Value = autoCompleteBox.Text;
                autoCompleteBox.Visible = false;
                tblMateriales.CurrentCell = tblMateriales.Rows[row].Cells[col + 1];
                e.SuppressKeyPress = true;
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable datosProveedores = BD.LlenarTabla("select id_proveedor,nombreproveedor from sis_proveedores"); // o datos simulados
            var buscador = new FormBuscadorGenerico(datosProveedores, "Buscar Proveedor", "Nombreproveedor");

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                txtCodigoProveedor.Text = buscador.IdSeleccionado.ToString();
                txtNombreProveedor.Text = buscador.NombreSeleccionado;
            }
        }

        private void tblProveedor_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {   
            if (e.RowIndex < 0 || e.ColumnIndex < 0) return; // Validar que la fila y columna sean válidas


            string consulta = "SELECT id_proveedor FROM sis_proveedores WHERE nombreproveedor = '" + tblProveedor.CurrentRow.Cells[0].Value.ToString() + "'";
            string codigo = BD.devolverUnValor(consulta);
            if (!string.IsNullOrEmpty(codigo))
            {
                txtCodigoProveedor.Text = codigo;
                txtNombreProveedor.Text = tblProveedor.CurrentRow.Cells[0].Value.ToString();
                tblMateriales.Focus();
                tblMateriales.CurrentCell = tblMateriales.Rows[0].Cells["id_material"];
                tblMateriales.BeginEdit(true);
            }
        }
    }
}
