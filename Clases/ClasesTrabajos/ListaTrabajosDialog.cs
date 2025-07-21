using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Vidrieria.Clases.ClasesTrabajos
{

    public partial class ListaTrabajosDialog : Form
    {
        public ListaTrabajosDialog(List<NuevoTrabajo> trabajos)
        {
            var label = new Label
            {
                Text = $"Total de trabajos: {trabajos.Count}",
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            var listBox = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10)
            };

            foreach (var trabajo in trabajos)
            {
                string nombre = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin nombre]" : trabajo.Nombre;
                string ancho = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin ancho]" : trabajo.Ancho.ToString()!;
                string alto = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin alto]" : trabajo.Alto.ToString()!;
                string cantidad = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin cantidad]" : trabajo.Cantidad.ToString()!;
                string costo = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin costo]" : trabajo.CostoSeleccionado.ToString()!;
                string precio = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin precio]" : trabajo.PrecioSeleccionado.ToString()!;
                string color = string.IsNullOrWhiteSpace(trabajo.Nombre) ? "[Sin color]" : trabajo.ColorSeleccionado!.ToString()!;

                listBox.Items.Add($"" +
                    $"{cantidad}:, " +
                    $"{nombre} " +
                    $"Ancho: {ancho}, " +
                    $"Alto: {alto}, " +
                    $"Costo: {costo}, " +
                    $"Precio: {precio}, " +
                    $"Color: {color}");
            }
            Controls.Add(listBox);
            Controls.Add(label);
            Text = "Lista de trabajos";
            Width = 800;
            Height = 300;
        }
    }

}
