using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Clientes
{
    public partial class AdministrarClientes : Form, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;

        private void Limpiar()
        {
            txtCodigo.Clear();
            txtNombre.Clear();
            txtTelefono.Clear();
            txtCorreo.Clear();
            txtIdentidad.Clear();
            txtRTN.Clear();
            txtDireccion.Clear();

            txtCodigo.BackColor = Color.White;
            txtNombre.BackColor = Color.White;
            txtTelefono.BackColor = Color.White;
            txtCorreo.BackColor = Color.White;
            txtIdentidad.BackColor = Color.White;
            txtRTN.BackColor = Color.White;
            txtDireccion.BackColor = Color.White;
        }

        private void CargarClientes()
        {
            DataTable datos = new DataTable();
            tblClientes.AutoGenerateColumns = false;
            string consulta = "SELECT id_cliente,nombrecliente, identidad, RTN, direccion, telefono, correo FROM sis_clientes";
            datos = BD.LlenarTabla(consulta);
            tblClientes.DataSource = datos;
        }

        private bool validarCampos()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) ||
                   !string.IsNullOrEmpty(txtIdentidad.Text) ||
                   !string.IsNullOrEmpty(txtRTN.Text) ||
                   !string.IsNullOrEmpty(txtDireccion.Text) ||
                   !string.IsNullOrEmpty(txtTelefono.Text) ||
                   !string.IsNullOrEmpty(txtCorreo.Text);
        }

        private void Guardar()
        {
            if (validarCampos())
            {
                Cliente cliente = new Cliente(txtCodigo.Text, txtNombre.Text, txtIdentidad.Text, txtRTN.Text, txtDireccion.Text, txtTelefono.Text, txtCorreo.Text);
                bool exito = BD.InsertarCliente(cliente);
                Limpiar();
                CargarClientes();
                MessageBox.Show(exito ? "Cliente guardado correctamente" : "Error al insertar cliente");
            }
        }




        public AdministrarClientes()
        {
            InitializeComponent();
            txtBuscarNombre.Focus();
            CargarClientes();
            this.FormBorderStyle = FormBorderStyle.FixedSingle; // o None
            this.BackColor = Color.WhiteSmoke; // fondo del hijo
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNombre.Text.Equals(""))
                {
                    MessageBox.Show(this, "El campo no puede estar vacio");

                    txtNombre.BackColor = Color.Yellow;
                    txtNombre.Focus();
                }
                else
                {
                    txtIdentidad.Focus();
                }
            }
        }

        private void txtIdentidad_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIdentidad.Text.Equals(""))
                {
                    MessageBox.Show(this, "El campo no puede estar vacio");

                    txtIdentidad.BackColor = Color.Yellow;
                    txtIdentidad.Focus();
                }
                else
                {
                    txtRTN.Focus();
                }
            }
        }

        private void txtRTN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIdentidad.Text.Equals(""))
                {
                    MessageBox.Show(this, "El campo no puede estar vacio");

                    txtRTN.BackColor = Color.Yellow;
                    txtRTN.Focus();
                }
                else
                {
                    txtDireccion.Focus();
                }
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIdentidad.Text.Equals(""))
                {
                    MessageBox.Show(this, "El campo no puede estar vacio");

                    txtDireccion.BackColor = Color.Yellow;
                    txtDireccion.Focus();
                }
                else
                {
                    txtTelefono.Focus();
                }
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtIdentidad.Text.Equals(""))
                {
                    MessageBox.Show(this, "El campo no puede estar vacio");

                    txtTelefono.BackColor = Color.Yellow;
                    txtTelefono.Focus();
                }
                else
                {
                    txtCorreo.Focus();
                }
            }
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarNombre.Text.Equals(""))
            {
                CargarClientes();
            }
            else
            {
                string consulta = "select id_cliente,nombrecliente,identidad,RTN,direccion,telefono,correo from sis_clientes where nombrecliente like '%" + txtBuscarNombre.Text + "%'";
                DataTable datos = BD.LlenarTabla(consulta);
                tblClientes.DataSource = datos;
            }
        }

        private void tblClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tblClientes.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells["id_cliente"].Value.ToString();
                txtNombre.Text = fila.Cells["nombrecliente"].Value.ToString();
                txtIdentidad.Text = fila.Cells["identidad"].Value.ToString();
                txtRTN.Text = fila.Cells["RTN"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCodigo.Text = BD.devolverUnValor("select isnull(max(id_cliente+1),1) from sis_clientes");
            txtNombre.Focus();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                Cliente cliente = new Cliente(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtIdentidad.Text,
                    txtRTN.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text);
                bool exito = BD.ActualizarCliente(cliente);
                Limpiar();
                MessageBox.Show(exito ? "Cliente actualizado correctamente" : "Error al actualizar cliente");
            }
        }

        private void AdministrarClientes_Load(object sender, EventArgs e)
        {

        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
