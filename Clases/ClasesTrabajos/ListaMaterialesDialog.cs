using Vidrieria.Modelos;

namespace Vidrieria.Clases.ClasesTrabajos
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Drawing.Printing;
    using System.Linq;
    using System.Windows.Forms;


    public class ListaMaterialesDialog : Form
    {
        private readonly List<MaterialesUsados> _materiales;
        private readonly ListBox listBox;
        private readonly Label label;

        public ListaMaterialesDialog(List<MaterialesUsados> materiales)
        {
            _materiales = materiales;

            Text = "Materiales Usados por Trabajo";
            Width = 800;
            Height = 500;

            label = new Label
            {
                Text = $"Total de materiales: {materiales.Count}",
                Dock = DockStyle.Top,
                Padding = new Padding(10),
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };

            listBox = new ListBox
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10)
            };

            var botonImprimir = new Button
            {
                Text = " Imprimir",
                Dock = DockStyle.Bottom,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter,
                ImageAlign = ContentAlignment.MiddleLeft,
                BackColor = Color.DarkSlateBlue,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10, FontStyle.Bold)
            };
            botonImprimir.Click += (s, e) => ImprimirMateriales();

            Controls.Add(listBox);
            Controls.Add(botonImprimir);
            Controls.Add(label);

            CargarMateriales();
        }

        private void CargarMateriales()
        {
            listBox.Items.Clear();

            var materialesAgrupados = _materiales
                .GroupBy(m => string.IsNullOrWhiteSpace(m.NombreTrabajo) ? "[Sin nombre de trabajo]" : m.NombreTrabajo)
                .OrderBy(g => g.Key);

            foreach (var grupo in materialesAgrupados)
            {
                listBox.Items.Add($"Trabajo: {grupo.Key}");

                foreach (var material in grupo)
                {
                    string descripcion = string.IsNullOrWhiteSpace(material.Descripcion) ? "[Sin descripción]" : material.Descripcion;
                    string utilizado = material.Utilizado.ToString("0.##");
                    listBox.Items.Add($"  - {descripcion} | Utilizado: {utilizado}");
                }

                listBox.Items.Add(""); // Línea en blanco opcional
            }
        }

        private void ImprimirMateriales()
        {
            var printDoc = new PrintDocument();
            var materialesAgrupados = _materiales
                .GroupBy(m => string.IsNullOrWhiteSpace(m.NombreTrabajo) ? "[Sin nombre de trabajo]" : m.NombreTrabajo)
                .OrderBy(g => g.Key)
                .ToList();

            int currentLine = 0;
            List<string> contenido = new();

            foreach (var grupo in materialesAgrupados)
            {
                contenido.Add($"Trabajo: {grupo.Key}");
                foreach (var material in grupo)
                {
                    string descripcion = string.IsNullOrWhiteSpace(material.Descripcion) ? "[Sin descripción]" : material.Descripcion;
                    string utilizado = material.Utilizado.ToString("0.##");
                    contenido.Add($"  - {descripcion} | Utilizado: {utilizado}");
                }
                contenido.Add("");
            }

            printDoc.PrintPage += (sender, e) =>
            {
                float y = 100;
                Font fuente = new Font("Segoe UI", 10);
                float lineHeight = fuente.GetHeight(e.Graphics) + 4;

                while (currentLine < contenido.Count)
                {
                    e.Graphics.DrawString(contenido[currentLine], fuente, Brushes.Black, new PointF(100, y));
                    y += lineHeight;
                    currentLine++;

                    if (y + lineHeight > e.MarginBounds.Bottom)
                    {
                        e.HasMorePages = true;
                        return;
                    }
                }

                e.HasMorePages = false;
                currentLine = 0;
            };

            using (var vistaPrevia = new PrintPreviewDialog())
            {
                vistaPrevia.Document = printDoc;
                vistaPrevia.Width = 800;
                vistaPrevia.Height = 600;
                vistaPrevia.ShowDialog();
            }
        }
    }

}
