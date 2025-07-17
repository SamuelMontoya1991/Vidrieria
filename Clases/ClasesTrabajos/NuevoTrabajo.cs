using System;
using System.Windows.Forms;

namespace Vidrieria.Clases.ClasesTrabajos
{
    public class NuevoTrabajo
    {
        public int? Id { get; set; }
        public double? Ancho { get; set; }
        public double? Alto { get; set; }
        public int? Cantidad { get; set; }
        public double? Area { get; set; }
        public string? Nombre { get; set; }
        public DataGridView? Aluminio { get; set; }
        public DataGridView? Hoja { get; set; }
        public DataGridView? Moldura { get; set; }
        public DataGridView? Accesorio { get; set; }
        public double? CostoSeleccionado { get; set; }
        public double? PrecioSeleccionado { get; set; }
        public string? ColorSeleccionado { get; set; }

        public NuevoTrabajo() { }

        public NuevoTrabajo(int? id, double ancho, double alto, int cantidad, double area, string? nombre, DataGridView? aluminio, DataGridView? hoja, DataGridView? moldura, DataGridView? accesorio, double? costoSeleccionado, double? crecioSeleccionado, string? colorSeleccionado)
        {
            Id = id;
            Ancho = ancho;
            Alto = alto;
            Cantidad = cantidad;
            Area = area;
            Nombre = nombre;
            Aluminio = aluminio;
            Hoja = hoja;
            Moldura = moldura;
            Accesorio = accesorio;
            CostoSeleccionado = costoSeleccionado;
            PrecioSeleccionado = crecioSeleccionado;
            ColorSeleccionado = colorSeleccionado;
        }
        public void agregarTrabajoExistente(NuevoTrabajo trabajoNuevo)
        {
            this.PrecioSeleccionado = Math.Round(this.PrecioSeleccionado.GetValueOrDefault() + trabajoNuevo.PrecioSeleccionado.GetValueOrDefault(), 2);
            this.CostoSeleccionado = Math.Round(this.CostoSeleccionado.GetValueOrDefault() + trabajoNuevo.CostoSeleccionado.GetValueOrDefault(), 2);
            this.Cantidad += trabajoNuevo.Cantidad;
            sumarMateriales(trabajoNuevo);
        }

        private void sumarMateriales(NuevoTrabajo nuevoTrabajo)
        {

            for (int i = 0; i < nuevoTrabajo.Aluminio!.RowCount; i++)
            {
                double PN = 0, PBR = 0, PM = 0;
                double usado = Convert.ToDouble(Aluminio!.Rows[i].Cells[6].Value) + Convert.ToDouble(nuevoTrabajo.Aluminio!.Rows[i].Cells[6].Value);
                Aluminio.Rows[i].Cells[6].Value = usado;
                PN = PN + Convert.ToDouble("" + nuevoTrabajo.Aluminio!.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + nuevoTrabajo.Aluminio!.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + nuevoTrabajo.Aluminio!.Rows[i].Cells[9].Value);

                Aluminio.Rows[i].Cells[7].Value = PN + Convert.ToDouble(Aluminio.Rows[i].Cells[7].Value);
                Aluminio.Rows[i].Cells[8].Value = PBR + Convert.ToDouble(Aluminio.Rows[i].Cells[8].Value);
                Aluminio.Rows[i].Cells[9].Value = PM + Convert.ToDouble(Aluminio.Rows[i].Cells[9].Value);
            }

            for (int i = 0; i < nuevoTrabajo.Hoja!.RowCount; i++)
            {
                double PN = 0, PBR = 0, PM = 0;
                double usado = Convert.ToDouble(Hoja!.Rows[i].Cells[6].Value) + Convert.ToDouble(nuevoTrabajo.Hoja!.Rows[i].Cells[6].Value);
                Hoja!.Rows[i].Cells[6].Value = usado;
                PN = PN + Convert.ToDouble("" + nuevoTrabajo.Hoja!.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + nuevoTrabajo.Hoja!.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + nuevoTrabajo.Hoja!.Rows[i].Cells[9].Value);

                Hoja!.Rows[i].Cells[7].Value = PN + Convert.ToDouble(Hoja!.Rows[i].Cells[7].Value);
                Hoja!.Rows[i].Cells[8].Value = PBR + Convert.ToDouble(Hoja!.Rows[i].Cells[8].Value);
                Hoja!.Rows[i].Cells[9].Value = PM + Convert.ToDouble(Hoja!.Rows[i].Cells[9].Value);
            }
            if (nuevoTrabajo.Moldura!.RowCount < 0)
            {
            }
            else
            {
                for (int i = 0; i < nuevoTrabajo.Moldura!.RowCount; i++)
                {
                    double PN = 0, PBR = 0, PM = 0;
                    double usado = Convert.ToDouble(Hoja!.Rows[i].Cells[6].Value) + Convert.ToDouble(nuevoTrabajo.Moldura!.Rows[i].Cells[6].Value);
                    Moldura!.Rows[i].Cells[6].Value = usado;
                    PN = PN + Convert.ToDouble("" + nuevoTrabajo.Moldura!.Rows[i].Cells[7].Value);
                    PBR = PBR + Convert.ToDouble("" + nuevoTrabajo.Moldura!.Rows[i].Cells[8].Value);
                    PM = PM + Convert.ToDouble("" + nuevoTrabajo.Moldura!.Rows[i].Cells[9].Value);

                    Moldura!.Rows[i].Cells[7].Value = PN + Convert.ToDouble(Moldura!.Rows[i].Cells[7].Value);
                    Moldura!.Rows[i].Cells[8].Value = PBR + Convert.ToDouble(Moldura!.Rows[i].Cells[8].Value);
                    Moldura!.Rows[i].Cells[9].Value = PM + Convert.ToDouble(Moldura!.Rows[i].Cells[9].Value);
                }
            }
            for (int i = 0; i < nuevoTrabajo.Accesorio!.RowCount; i++)
            {
                double PN = 0, PBR = 0, PM = 0;
                double usado = Convert.ToDouble(Hoja!.Rows[i].Cells[6].Value) + Convert.ToDouble(nuevoTrabajo.Accesorio!.Rows[i].Cells[6].Value);
                Accesorio!.Rows[i].Cells[6].Value = usado;
                PN = PN + Convert.ToDouble("" + nuevoTrabajo.Accesorio!.Rows[i].Cells[7].Value);
                PBR = PBR + Convert.ToDouble("" + nuevoTrabajo.Accesorio!.Rows[i].Cells[8].Value);
                PM = PM + Convert.ToDouble("" + nuevoTrabajo.Accesorio!.Rows[i].Cells[9].Value);

                Accesorio!.Rows[i].Cells[7].Value = PN + Convert.ToDouble(Accesorio!.Rows[i].Cells[7].Value);
                Accesorio!.Rows[i].Cells[8].Value = PBR + Convert.ToDouble(Accesorio!.Rows[i].Cells[8].Value);
                Accesorio!.Rows[i].Cells[9].Value = PM + Convert.ToDouble(Accesorio!.Rows[i].Cells[9].Value);
            }
        }

    }
}
