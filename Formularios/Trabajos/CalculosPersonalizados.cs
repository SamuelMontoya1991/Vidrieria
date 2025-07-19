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
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Cotizaciones;
using Vidrieria.Formularios.Factura;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Trabajos
{
    public partial class CalculosPersonalizados : Form, IFormularioConUsuario, IFormularioConTema
    {
        private ConexionDB BD = new ConexionDB();
        Tema temaActual;
        private Usuario usuario;
        List<NuevoTrabajo> trabajos = new List<NuevoTrabajo>();

        public CalculosPersonalizados()
        {
            InitializeComponent();
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void tblTrabajos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tblTrabajos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in tblTrabajos.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            tblTrabajos.Rows.Remove(row);
                        }
                    }
                }
            }
            if (e.KeyCode == Keys.Enter) {
                if (tblTrabajos.CurrentCell.ColumnIndex == 5) { 
                    calcularPrecios();
                }
            }
        }

        private void txtReferencia_TextChanged(object sender, EventArgs e)
        {
            if (txtReferencia.Text.Equals(""))
            {
                CargarTrabajos();
            }
            else
            {
                string consulta = "SELECT UPPER(descripcion) as referencia FROM sis_trabajos where extra=1 and descripcion like '%" + txtReferencia.Text + "%'";
                DataTable datos = BD.LlenarTabla(consulta);
                tblNombres.DataSource = datos;
            }
        }

        private void CargarTrabajos()
        {
            DataTable datos = new DataTable();
            tblNombres.AutoGenerateColumns = false;
            string consulta = "SELECT UPPER(descripcion) as referencia FROM sis_trabajos where extra=1";
            datos = BD.LlenarTabla(consulta);
            tblNombres.DataSource = datos;
        }
        private void calcularPrecios() {
            for (int i = 0; i < tblTrabajos.RowCount; i++) { 
                decimal alto = Convert.ToDecimal(tblTrabajos.Rows[i].Cells[1].Value);
                decimal ancho = Convert.ToDecimal(tblTrabajos.Rows[i].Cells[2].Value);
                decimal area = (alto * ancho)/144;
                int cantidad = Convert.ToInt32(tblTrabajos.Rows[i].Cells[4].Value);
                decimal precio = Convert.ToDecimal(tblTrabajos.Rows[i].Cells[5].Value);
                decimal precioTotal = (cantidad * precio);

                tblTrabajos.Rows[i].Cells[3].Value = area.ToString("0.00");
                tblTrabajos.Rows[i].Cells[6].Value = precioTotal.ToString("0.00");
            }
        }
        private bool validarCampos()
        {
            if (tblTrabajos.RowCount == 0)
            {
                MessageBox.Show("Debe agregar al menos un trabajo antes de continuar.");
                return false;
            }
            foreach (DataGridViewRow row in tblTrabajos.Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[2].Value == null || row.Cells[4].Value == null || row.Cells[5].Value == null)
                {
                    MessageBox.Show("Todos los campos deben estar completos.");
                    return false;
                }
            }
            return true;
        }

        private void tblNombres_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tblTrabajos.Rows.Add(tblNombres.CurrentRow.Cells[0].Value,"1","1","1","1","0","0" );
            txtAncho.Focus();
        }

        private void txtAncho_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtAncho.Text.Equals(""))
                    {
                        MessageBox.Show(this, "El campo no puede estar vacio");

                        txtAncho.Focus();
                    }
                    else
                    {
                        tblTrabajos.Rows[tblTrabajos.RowCount - 1].Cells[1].Value = txtAncho.Text;
                        calcularPrecios();
                        txtAlto.Focus();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtAlto_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                try
                {
                    if (txtAlto.Text.Equals(""))
                    {
                        MessageBox.Show(this, "El campo no puede estar vacio");

                        txtAlto.Focus();
                    }
                    else
                    {
                        tblTrabajos.Rows[tblTrabajos.RowCount - 1].Cells[2].Value = txtAlto.Text;
                        calcularPrecios();
                        txtCantidad.Focus();
                    }
                }
                catch (Exception ex)
                {

                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                tblTrabajos.Columns[5].ReadOnly = false;
                if (string.IsNullOrWhiteSpace(txtCantidad.Text))
                {
                    MessageBox.Show(this, "El campo no puede estar vacío");
                    txtCantidad.Focus();
                }
                else
                {
                    int lastRow = tblTrabajos.RowCount - 1;
                    tblTrabajos.Rows[lastRow].Cells[4].Value = txtCantidad.Text;
                       
                    tblTrabajos.CurrentCell = tblTrabajos.Rows[lastRow].Cells[5];

                    tblTrabajos.Focus();
                    e.Handled = true;
                }
            }
        }

        private void tblTrabajos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 5)
            {
                if (string.IsNullOrWhiteSpace(tblTrabajos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value?.ToString()))
                {
                    MessageBox.Show(this, "El campo no puede estar vacío");
                    tblTrabajos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                }
                else
                {
                    // Asegurarse de que el valor sea un número válido
                    if (!decimal.TryParse(tblTrabajos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString(), out _))
                    {
                        MessageBox.Show(this, "El precio debe ser un número válido");
                        tblTrabajos.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "0";
                    }
                }
                calcularPrecios();
                txtAlto.Text ="1";
                txtAncho.Text = "1";
                txtCantidad.Text = "1";
                txtReferencia.Text = "";
                txtReferencia.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string nuevoGasto = PedirDescripcion.PedirDescripcionGeneral("Nuevo Trabajo", "Ingrese la descripción del nuevo trabajo:");

            if (!string.IsNullOrEmpty(nuevoGasto))
            {
                string consulta = @"INSERT INTO Sis_Trabajos (id_trabajo, Descripcion,extra) VALUES (@id_trabajo, @descripcion, @extra)";
                var parametros = new Dictionary<string, object>
                {
                    { "@id_trabajo", BD.devolverUnValor("select isnull(max(id_trabajo+1),1) from sis_trabajos") },
                    { "@descripcion", nuevoGasto },
                    { "@extra", 1}
                };

                bool success = BD.InsertarAlgo(consulta, parametros);
                CargarTrabajos();

            }
            else
            {
                MessageBox.Show("Debe ingresar una descripción válida para el nuevo trabajo.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos()) {
                trabajos.Clear();
                for (int i = 0; i < tblTrabajos.RowCount; i++)
                {
                    NuevoTrabajo trabajo = new NuevoTrabajo
                    {
                        Id = Convert.ToInt32(BD.devolverUnValor("SELECT id_trabajo FROM sis_trabajos where descripcion ='"+ tblTrabajos.Rows[i].Cells[0].Value.ToString() + "'")),
                        Nombre = tblTrabajos.Rows[i].Cells[0].Value.ToString(),
                        Ancho = Convert.ToDouble(tblTrabajos.Rows[i].Cells[1].Value),
                        Alto = Convert.ToDouble(tblTrabajos.Rows[i].Cells[2].Value),
                        Area = Convert.ToDouble(tblTrabajos.Rows[i].Cells[3].Value),
                        Cantidad = Convert.ToInt32(tblTrabajos.Rows[i].Cells[4].Value),
                        PrecioSeleccionado = Convert.ToDouble(tblTrabajos.Rows[i].Cells[6].Value)
                    };
                    trabajos.Add(trabajo);
                }
                MessageBox.Show("Trabajos guardados correctamente. Puede proceder a cotizar o facturar", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnCotizar_Click(object sender, EventArgs e)
        {
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<NuevaCotizacion>(this.usuario, this.trabajos, 0, null, temaActual);
            }
            else
            {
                MessageBox.Show("No se pudo abrir el formulario de cotización.");
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<Facturar>(this.usuario, this.trabajos, 0, null, temaActual);
            }
            else
            {
                MessageBox.Show("No se pudo abrir el formulario de facturación.");
            }
        }
    }
}
