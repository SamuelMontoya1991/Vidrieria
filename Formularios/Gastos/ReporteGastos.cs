using System;
using System.Data;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;

namespace Vidrieria.Formularios.Gastos
{
    public partial class ReporteGastos : Form, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;

        private void generarReporte()
        {
            DateTime fecha1 = txtFecha1.Value.Date;
            DateTime fecha2 = txtFecha2.Value.Date;

            string fechaInicio = fecha1.ToString("yyyy/MM/dd") + " 00:00:00";
            string fechaFin = fecha2.ToString("yyyy/MM/dd") + " 23:59:59";

            string filtroFechas = $"Fecha BETWEEN '{fechaInicio}' AND '{fechaFin}'";

            string queryConteo = $"SELECT COUNT(id_gasto) FROM vwgastos WHERE {filtroFechas}";
            string resultado = BD.devolverUnValor(queryConteo);

            if (resultado == "0")
            {
                MessageBox.Show("No hay datos para mostrar en este rango de fechas");
            }
            else
            {
                string consulta = $"SELECT DISTINCT tipo_gasto, descripcion, '' AS total FROM vwgastos WHERE {filtroFechas}";
                Console.WriteLine(consulta);

                DataTable tabla = BD.LlenarTabla(consulta);
                double total = 0.0;

                foreach (DataRow fila in tabla.Rows)
                {
                    string tipoGasto = fila["tipo_gasto"].ToString();
                    string querySuma = $"SELECT SUM(cantidad) FROM vwgastos WHERE tipo_gasto = '{tipoGasto}' AND {filtroFechas}";
                    string suma = BD.devolverUnValor(querySuma);

                    fila["total"] = suma;
                    total += double.TryParse(suma, out double val) ? val : 0.0;
                }

                tblGastos.DataSource = tabla;
                txtTotal.Text = total.ToString("N2");
            }
        }
        private void desglosarReporte()
        {
            DateTime fecha1 = txtFecha1.Value.Date;
            DateTime fecha2 = txtFecha2.Value.Date;

            string fechaInicio = fecha1.ToString("yyyy/MM/dd") + " 00:00:00";
            string fechaFin = fecha2.ToString("yyyy/MM/dd") + " 23:59:59";

            string filtroFechas = $"Fecha BETWEEN '{fechaInicio}' AND '{fechaFin}'";

            string queryConteo = $"SELECT COUNT(id_gasto) FROM vwgastos WHERE {filtroFechas}";
            string resultado = BD.devolverUnValor(queryConteo);

            if (resultado == "0")
            {
                MessageBox.Show("No hay datos para mostrar en este rango de fechas");
            }
            else
            {
                string consulta = @"
                                SELECT tipo_gasto, 
                                       descripcion + ' ' + observacion + ' fact# ' + nodocumento AS descripcion, 
                                       cantidad as total, 
                                       fechacompra 
                                FROM vwgastos 
                                WHERE " + filtroFechas;

                Console.WriteLine(consulta);

                DataTable tabla = BD.LlenarTabla(consulta);
                double total = 0.0;

                foreach (DataRow fila in tabla.Rows)
                {
                    if (double.TryParse(fila["total"].ToString(), out double cantidad))
                    {
                        total += cantidad;
                    }
                }

                tblGastos.DataSource = tabla;
                txtTotal.Text = total.ToString("N2");
            }
        }

        public ReporteGastos()
        {
            InitializeComponent();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generarReporte();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDesglosar_Click(object sender, EventArgs e)
        {
            desglosarReporte();
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
