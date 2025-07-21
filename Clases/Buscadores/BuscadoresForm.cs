using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vidrieria.Clases.Buscadores
{
    public partial class FormBuscadorGenerico : Form
    {
        public int IdSeleccionado { get; private set; }
        public string NombreSeleccionado { get; private set; }

        private DataView vistaDatos;
        private string columnaFiltro;

        public FormBuscadorGenerico(DataTable datos, string titulo, string columnaFiltrar)
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = titulo;
            columnaFiltro = columnaFiltrar;
            vistaDatos = new DataView(datos);


            InicializarComponentes();
            dgvBusqueda.DataSource = vistaDatos;
        }

        TextBox txtBuscar;
        DataGridView dgvBusqueda;

        private void InicializarComponentes()
        {
            this.Width = 500;
            this.Height = 400;

            txtBuscar = new TextBox() { Width = 300, Top = 10, Left = 10 };
            txtBuscar.TextChanged += TxtBuscar_TextChanged;
            this.Controls.Add(txtBuscar);

            dgvBusqueda = new DataGridView()
            {
                Top = 40,
                Left = 10,
                Width = 460,
                Height = 300,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoGenerateColumns = true
            };

            dgvBusqueda.CellDoubleClick += DgvBusqueda_CellDoubleClick;
            this.Controls.Add(dgvBusqueda);
        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            string texto = txtBuscar.Text.Replace("'", "''");
            vistaDatos.RowFilter = $"{columnaFiltro} LIKE '%{texto}%'";
        }

        private void DgvBusqueda_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                IdSeleccionado = Convert.ToInt32(dgvBusqueda.Rows[e.RowIndex].Cells[0].Value);
                NombreSeleccionado = dgvBusqueda.Rows[e.RowIndex].Cells[1].Value.ToString();

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }

}
