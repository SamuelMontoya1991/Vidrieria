using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Gastos
{
    public partial class NuevoGasto : Form, IFormularioConUsuario,IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;
        Usuario? usuario;

        public NuevoGasto()
        {
            InitializeComponent();
            llenarCombo();
        }

        private void llenarCombo()
        {
            cmbGastos.DisplayMember = "descripcion";
            cmbGastos.DataSource = BD.llenarCombobox("SELECT descripcion FROM sis_tipo_gastos", "--Seleccione un gasto--");
        }

        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtCantidad.Text) || txtCantidad.Text == "0.00")
            {
                MessageBox.Show("Debe ingresar una cantidad válida.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtFactura.Text))
            {
                MessageBox.Show("Debe ingresar un número de factura.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (string.IsNullOrEmpty(txtObservacion.Text))
            {
                MessageBox.Show("Debe ingresar una nota del gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (cmbGastos.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar un tipo de gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

        private void limpiarCampos()
        {
            txtCantidad.Clear();
            txtFactura.Text = string.Empty;
            txtFecha.Value = DateTime.Now;
            txtObservacion.Text = string.Empty;
            cmbGastos.SelectedIndex = 0;
        }

        private void Guardar()
        {
            if (validarCampos())
            {
                TipoGasto gasto = new TipoGasto
                {
                    id = Convert.ToInt32(BD.devolverUnValor("SELECT ISNULL(MAX(id_gasto+1),1) FROM sis_gastos")),
                    tipoGasto = BD.devolverUnValor("SELECT id_gasto FROM sis_tipo_gastos WHERE descripcion ='" + cmbGastos?.SelectedItem!.ToString() + "'"),
                    cantidad = Convert.ToDecimal(txtCantidad.Text),
                    fechaCompra = txtFecha.Value,
                    documento = txtFactura.Text,
                    observacion = txtObservacion.Text,
                    idUsuario = usuario?.Id_Usuario ?? 0
                };
                bool exito = BD.InsertarGasto(gasto);
                MessageBox.Show(exito ? "Gasto guardado correctamente." : "Error al guardar el gasto.", "Información", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                limpiarCampos();
            }
        }



        private void txtCantidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtFactura.Focus();
                int numero = Convert.ToInt32(txtCantidad.Text);
                txtCantidad.Text = numero.ToString("N2");
            }
        }

        private void txtFactura_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtObservacion.Focus();
            }
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            string nuevoGasto = PedirDescripcion.PedirDescripcionGasto("Nuevo Gasto", "Ingrese la descripción del nuevo gasto:");

            if (!string.IsNullOrEmpty(nuevoGasto))
            {
                string consulta = @"INSERT INTO Sis_Tipo_Gastos (id_gasto, Descripcion) VALUES (@id_gasto, @descripcion)";
                var parametros = new Dictionary<string, object>
                {
                    { "@id_gasto", BD.devolverUnValor("select isnull(max(id_gasto+1),1) from sis_tipo_gastos") },
                    { "@descripcion", nuevoGasto }
                };

                bool success = BD.InsertarAlgo(consulta, parametros);
                llenarCombo();

            }
            else
            {
                MessageBox.Show("Debe ingresar una descripción válida para el nuevo gasto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Permitir control, dígitos, y una coma o punto (pero solo una vez)
            if (!char.IsControl(e.KeyChar) &&
                !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // Solo permitir un punto o coma
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.Contains(".")))
            {
                e.Handled = true;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void cmbGastos_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtCantidad.Focus();
            txtCantidad.SelectAll();
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(temaActual);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        public void InicializarUsuario(Usuario usuario)
        {
           this.usuario = usuario;
        }

        
    }
}
