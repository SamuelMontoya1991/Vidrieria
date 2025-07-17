using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Factura
{

    public partial class InformacionFactura : Form, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;
        ModeloCai? globalcai = null;

        private bool modificandoTexto = false;



        private void LimpiarCampos(bool opcion)
        {
            txtCodigo.Clear();
            txtRangoInicial.Clear();
            txtRangoFinal.Clear();
            txtFecha.Value = DateTime.Now;
            txtRangoInicial.Enabled = !opcion;
            txtRangoFinal.Enabled = !opcion;
            txtCodigo.Enabled = !opcion;
            txtFecha.Enabled = !opcion;

        }
        public InformacionFactura()
        {
            InitializeComponent();
            llenarTabla();

        }
        private void llenarTabla()
        {
            LimpiarCampos(true);
            DataTable datos = new DataTable();
            datos = BD.LlenarTabla("select id_cai,rango_inicial,rango_final,fecha_limite,case when estado=1 then 'Activo' else 'Inactivo' end as estado from sis_cai");
            tblCai.AutoGenerateColumns = false;
            tblCai.DataSource = datos;
        }

        private bool validarCampos()
        {
            return !string.IsNullOrEmpty(txtCodigo.Text) ||
                   !string.IsNullOrEmpty(txtRangoInicial.Text) ||
                   !string.IsNullOrEmpty(txtRangoFinal.Text);

        }
        private void Guardar()
        {
            if (validarCampos())
            {
                ModeloCai cai = new ModeloCai(txtCodigo.Text, txtRangoInicial.Text, txtRangoFinal.Text, txtFecha.Value.ToString("yyyy-MM-dd"), 1);
                bool exito = BD.InsertarCai(cai);
                LimpiarCampos(true);
                MessageBox.Show(exito ? "CAI guardado correctamente" : "Error al insertar CAI");
            }
        }
        private void Actualizar(ModeloCai cai)
        {
            if (validarCampos())
            {
                bool exito = BD.ActualizarCai(globalcai);

                MessageBox.Show(exito ? "CAI actualizado correctamente" : "Error al actualizar CAI");
                if (exito)
                {
                    LimpiarCampos(true);

                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (modificandoTexto) return;

            modificandoTexto = true;

            string texto = txtCodigo.Text.Replace("-", ""); // Eliminar guiones existentes
            StringBuilder formateado = new StringBuilder();

            for (int i = 0; i < texto.Length; i++)
            {
                if (i > 0 && i % 6 == 0)
                {
                    formateado.Append("-");
                }
                formateado.Append(texto[i]);
            }

            int pos = txtCodigo.SelectionStart;
            txtCodigo.Text = formateado.ToString();
            txtCodigo.SelectionStart = pos + (txtCodigo.Text.Length - texto.Length);

            modificandoTexto = false;
        }

        private void txtCodigo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRangoInicial.Focus();
            }
        }

        private void txtRangoInicial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRangoFinal.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarCampos(false);
        }

        private void tblCai_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tblCai.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells["id_cai"].Value.ToString();
                txtRangoInicial.Text = fila.Cells["rango_inicial"].Value.ToString();
                txtRangoFinal.Text = fila.Cells["rango_final"].Value.ToString();
                txtFecha.Value = DateTime.Parse(fila.Cells["fecha_limite"].Value.ToString());

                globalcai = new ModeloCai(
                    id_cai: fila.Cells["id_cai"].Value.ToString(),
                    cai: txtCodigo.Text,
                    rango_inicial: txtRangoInicial.Text,
                    rango_final: txtRangoFinal.Text,
                    fecha_limite: txtFecha.Value.ToString("MM-dd-yyyy"),
                    estado: fila.Cells["estado"].Value.ToString().Equals("Activo") ? 1 : 0
                );
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnActualilzar_Click(object sender, EventArgs e)
        {
            Actualizar(globalcai!);
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
