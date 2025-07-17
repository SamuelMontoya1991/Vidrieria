using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Cotizaciones;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.ReportesEnSistema
{
    public partial class ReporteCotizaciones : Form, IFormularioConUsuario, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Usuario? usuario;
        Tema temaActual;

        private void generarReporte(string fechaInicio, string fechaFin, string nombre)
        {
            string filtroFechas = $"Fecha BETWEEN '{fechaInicio}' AND '{fechaFin}'";

            if (!string.IsNullOrEmpty(nombre))
            {
                filtroFechas += $" AND NombreCliente LIKE '%{nombre}%'";
            }

            string queryConteo = $"SELECT COUNT(id_cotizacion) FROM vwCotizaciones WHERE {filtroFechas}";


            string resultado = BD.devolverUnValor(queryConteo);

            if (resultado == "0")
            {
                MessageBox.Show("No hay datos para mostrar en este rango de fechas");
            }
            else
            {
                string consulta = $"SELECT Id_cotizacion,NombreCliente,Fecha,NombreVendedor,sum(cantidad) AS Objetos,sum(precio*cantidad) as total from vwCotizaciones WHERE {filtroFechas} GROUP BY Id_cotizacion, NombreCliente, Fecha, NombreVendedor";

                DataTable tabla = BD.LlenarTabla(consulta);
                tblCotizaciones.AutoGenerateColumns = false;
                tblCotizaciones.DataSource = tabla;
                calcularTotales();
            }
        }
        private void generar()
        {
            DateTime fecha1 = txtFecha1.Value.Date;
            DateTime fecha2 = txtFecha2.Value.Date;
            string fechaInicio = fecha1.ToString("yyyy/MM/dd") + " 00:00:00";
            string fechaFin = fecha2.ToString("yyyy/MM/dd") + " 23:59:59";
            string nombrecliente = "";
            if (tblClientes.SelectedRows.Count > 0 && tblClientes.SelectedRows[0].Cells[0].Value != null)
            {
                nombrecliente = tblClientes.SelectedRows[0].Cells[0].Value.ToString()!;
            }
            generarReporte(fechaInicio, fechaFin, nombrecliente);
        }
        private void calcularTotales()
        {
            decimal suma = 0;
            int objetos = 0;
            for (int i = 0; i < tblCotizaciones.RowCount; i++)
            {
                decimal valor = Convert.ToDecimal(tblCotizaciones.Rows[i].Cells["total"].Value);
                int cantidad = Convert.ToInt32(tblCotizaciones.Rows[i].Cells["objetos"].Value);
                suma += valor;
                objetos += cantidad;
            }

            // Agregar una fila si no hay ninguna
            if (tblTotales.Columns.Contains("totalobjetos") && tblTotales.Columns.Contains("totalcotizado"))
            {
                int rowIndex = tblTotales.Rows.Add();
                tblTotales.Rows[rowIndex].Cells["totalobjetos"].Value = objetos;
                tblTotales.Rows[rowIndex].Cells["totalcotizado"].Value = suma;
            }
            else
            {
                MessageBox.Show("Las columnas 'totalobjetos' o 'totalcotizado' no existen en tblTotales.");
            }
        }

        public ReporteCotizaciones()
        {
            InitializeComponent();
        }



        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generar();
        }

        private void tblClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            generar();
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text.IsNullOrEmpty())
            {
                string consulta = "select distinct nombrecliente as nombre from vwcotizaciones";
                DataTable tabla = BD.LlenarTabla(consulta);
                tblClientes.AutoGenerateColumns = false;
                tblClientes.DataSource = tabla;
            }
            else
            {
                string consulta = "select distinct nombrecliente as nombre from vwcotizaciones where nombrecliente like '%" + txtNombreCliente.Text.Trim() + "%'";
                DataTable tabla = BD.LlenarTabla(consulta);
                tblClientes.AutoGenerateColumns = false;
                tblClientes.DataSource = tabla;
            }
        }

        private void tblCotizaciones_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTestInfo = tblCotizaciones.HitTest(e.X, e.Y);
                if (hitTestInfo.RowIndex >= 0)
                {
                    tblCotizaciones.ClearSelection(); // Deselecciona todas
                    tblCotizaciones.Rows[hitTestInfo.RowIndex].Selected = true; // Selecciona la fila clickeada
                    tblCotizaciones.CurrentCell = tblCotizaciones.Rows[hitTestInfo.RowIndex].Cells[0]; // Opcional
                    menuDerecho.Show(tblCotizaciones, e.Location);
                }
            }
        }

        private void verCotizacionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idCotizacion = Convert.ToInt32(tblCotizaciones.SelectedRows[0].Cells[0].Value);
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<CotizacionDetalle>(this.usuario!, null, idCotizacion);
            }
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void txtFecha1_ValueChanged(object sender, EventArgs e)
        {
            generar();
        }

        private void txtFecha2_ValueChanged(object sender, EventArgs e)
        {
            generar();
        }

        private void txtFecha1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtFecha2.Focus();
                generar();
            }
        }

        private void txtFecha2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtNombreCliente.Focus();
                generar();
            }
        }

        private void verMaterialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int idCotizacion = Convert.ToInt32(tblCotizaciones.SelectedRows[0].Cells[0].Value);
            List<MaterialesUsados> materiales = BD.obtenerMaterialesUsados(idCotizacion);
            if (materiales.Count > 0)
            {
                var dialog = new ListaMaterialesDialog(materiales);
                dialog.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No hay materiales usados en esta cotización.");
            }
        }

        private void tblCotizaciones_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int idCotizacion = Convert.ToInt32(tblCotizaciones.SelectedRows[0].Cells[0].Value);
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                padre.AbrirFormularioCentrado<CotizacionDetalle>(this.usuario!, null, idCotizacion);
            }
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
