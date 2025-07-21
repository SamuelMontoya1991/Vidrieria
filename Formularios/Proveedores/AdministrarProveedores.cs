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
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Proveedores
{
    public partial class AdministrarProveedores : Form, IFormularioConUsuario,IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;
        Usuario? usuario;
        public AdministrarProveedores()
        {
            InitializeComponent();
            cargarProveedores();
        }

        private void cargarProveedores()
        {
            string consulta = "select id_proveedor, nombreproveedor,identidad, RTN, direccion ,telefono,correo from sis_proveedores";
            try
            {
                DataTable tabla = new DataTable();
                tabla = BD.LlenarTabla(consulta);
                tblProveedores.DataSource = tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void limpiarCampos()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            txtIdentidad.Text = "";
            txtRTN.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtCorreo.Text = "";
        }
        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtIdentidad.Text) ||
                string.IsNullOrWhiteSpace(txtRTN.Text) || string.IsNullOrWhiteSpace(txtDireccion.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text))
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void txtBuscarNombre_TextChanged(object sender, EventArgs e)
        {
            if (txtBuscarNombre.Text.Equals(""))
            {
                cargarProveedores();
            }
            else {
                string consulta = "select id_proveedor, nombreproveedor,identidad, RTN, direccion ,telefono,correo from sis_proveedores where nombreproveedor like '%" + txtBuscarNombre.Text + "%'";
                try
                {
                    DataTable tabla = new DataTable();
                    tabla = BD.LlenarTabla(consulta);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al buscar proveedores: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } 

        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(BD.devolverUnValor("select isnull(max(id_proveedor+1),1) from sis_proveedores"));
            txtCodigo.Text = id.ToString();
            txtNombre.Focus();
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNombre.Text.Equals(""))
                {

                }
                else {
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
                if (txtTelefono.Text.Equals(""))
                {
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
                if (txtRTN.Text.Equals(""))
                {
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
                if (txtCorreo.Text.Equals(""))
                {
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
                if (txtDireccion.Text.Equals(""))
                {
                }
                else
                {
                    btnGuardar.Focus();
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarCampos()) { 
                NuevoProveedor proveedor = new NuevoProveedor(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtIdentidad.Text,
                    txtRTN.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text
                );

                if (proveedor != null) { 
                    bool exito = BD.InsertarProveedor(proveedor);
                    if (exito)
                    {
                        MessageBox.Show("Proveedor guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarProveedores();
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
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

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            limpiarCampos();
        }

        private void tblProveedores_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow fila = tblProveedores.Rows[e.RowIndex];

                txtCodigo.Text = fila.Cells["id_proveedor"].Value.ToString();
                txtNombre.Text = fila.Cells["nombreproveedor"].Value.ToString();
                txtIdentidad.Text = fila.Cells["identidad"].Value.ToString();
                txtRTN.Text = fila.Cells["RTN"].Value.ToString();
                txtTelefono.Text = fila.Cells["telefono"].Value.ToString();
                txtCorreo.Text = fila.Cells["correo"].Value.ToString();
                txtDireccion.Text = fila.Cells["direccion"].Value.ToString();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (validarCampos())
            {
                NuevoProveedor proveedor = new NuevoProveedor(
                    txtCodigo.Text,
                    txtNombre.Text,
                    txtIdentidad.Text,
                    txtRTN.Text,
                    txtDireccion.Text,
                    txtTelefono.Text,
                    txtCorreo.Text
                );

                if (proveedor != null)
                {
                    bool exito = BD.ActualizarProveedor(proveedor);
                    if (exito)
                    {
                        MessageBox.Show("Proveedor actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        cargarProveedores();
                        limpiarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el proveedor.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
