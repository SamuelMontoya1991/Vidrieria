using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Login
{
    public partial class AdministrarUsuarios : Form, IFormularioConTema
    {
        Usuario Usuario = new Usuario();
        ConexionDB BD = new ConexionDB();
        Tema temaActual;

        private void VerificarCoincidenciaPasswords()
        {
            if (txtPassword.Text == txtConfirmarPassword.Text && txtPassword.Text != "")
            {
                txtPassword.BackColor = Color.LightGreen;
                txtConfirmarPassword.BackColor = Color.LightGreen;
            }
            else
            {
                txtPassword.BackColor = Color.Red;
                txtConfirmarPassword.BackColor = Color.Red;
            }
        }
        private void pasarDatos(Usuario usuario)
        {
            string[] nombres = usuario.Nombre!.Split(' ');
            
            if (nombres.Length > 1)
            {
                txtNombre.Text = nombres[0];
                txtApellido.Text = nombres[1];
            }
            else {
                txtNombre.Text = nombres[0];
            }

                txtUsuario.Text = usuario.nombreUsuario;
            //txtPassword.Text = usuario.Clave;
            cmbTipo.SelectedIndex = usuario.Nivel.HasValue ? usuario.Nivel.Value : -1;
            this.Usuario = usuario;
        }
        private void limpiarCampos()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtUsuario.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtConfirmarPassword.Text = string.Empty;
            cmbTipo.SelectedIndex = 0;
        }
        private bool validarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtApellido.Text) ||
                string.IsNullOrWhiteSpace(txtUsuario.Text) || string.IsNullOrWhiteSpace(txtPassword.Text) ||
                string.IsNullOrWhiteSpace(txtConfirmarPassword.Text) || cmbTipo.SelectedIndex == 0)
            {
                MessageBox.Show("Por favor, complete todos los campos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void llenarTabla()
        {
            limpiarCampos();
            tblUsuarios.DataSource = BD.LlenarTabla("select id_usuario,nombre,usuario,clave,nivel,id_tipo,estado from vwusuarios where estado=1");
        }
        private void Actualizar()
        {
            if (validarCampos())
            {
                Usuario.Nombre = txtNombre.Text + " " + txtApellido.Text;
                Usuario.nombreUsuario = txtUsuario.Text;
                Usuario.Clave = txtPassword.Text;
                Usuario.Nivel = cmbTipo.SelectedIndex;
                Usuario.Estado = 1;

                bool exito = BD.ActualizarUsuario(this.Usuario);
                if (exito)
                {
                    MessageBox.Show("Usuario actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarTabla();
                    limpiarCampos();
                    btnGuardar.Enabled = true;
                    btnActualizar.Enabled = false;
                    btnBaja.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Error al actualizar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void Guardar()
        {
            if (validarCampos())
            {
                Usuario.Id_Usuario = Convert.ToInt32(BD.devolverUnValor("select isnull(max(id_usuario+1),1) from sis_usuarios"));
                Usuario.Nombre = txtNombre.Text + " " + txtApellido.Text;
                Usuario.nombreUsuario = txtUsuario.Text;
                Usuario.Clave = txtPassword.Text;
                Usuario.Nivel = cmbTipo.SelectedIndex;
                Usuario.Estado = 1;
                bool exito = BD.InsertarUsuario(Usuario);
                if (exito)
                {
                    MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    llenarTabla();
                    limpiarCampos();
                }
                else
                {
                    MessageBox.Show("Error al guardar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public AdministrarUsuarios()
        {
            InitializeComponent();
            btnActualizar.Enabled = false;
            btnBaja.Enabled = false;
            cmbTipo.DataSource = BD.llenarCombobox("select descripcion from sis_niveles", "-seleccione un nivel-");
            llenarTabla();
        }




        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtApellido.Focus();
            }
        }

        private void txtApellido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtUsuario.Focus();
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtConfirmarPassword.Focus();
            }
        }

        private void tblUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Usuario usuario = new Usuario();
            usuario.Id_Usuario = Convert.ToInt32(tblUsuarios.CurrentRow.Cells[0].Value);
            usuario.Nombre = tblUsuarios.CurrentRow.Cells[1].Value.ToString();
            usuario.nombreUsuario = tblUsuarios.CurrentRow.Cells[2].Value.ToString();
            usuario.Clave = tblUsuarios.CurrentRow.Cells[3].Value.ToString();
            usuario.Nivel = Convert.ToInt32(tblUsuarios.CurrentRow.Cells["tipo"].Value);
            usuario.Estado = Convert.ToInt32(tblUsuarios.CurrentRow.Cells["estado"].Value);
            btnGuardar.Enabled = false;
            btnActualizar.Enabled = true;
            btnBaja.Enabled = true;
            pasarDatos(usuario);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            VerificarCoincidenciaPasswords();
        }

        private void txtConfirmarPassword_TextChanged(object sender, EventArgs e)
        {
            VerificarCoincidenciaPasswords();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Actualizar();
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {   
            string id = tblUsuarios.CurrentRow.Cells[0].Value.ToString();
            Dictionary<string, object> parametros = new Dictionary<string, object>
            {
                { "@id_usuario", id },
                { "@estado", 0 }
            };

            bool exito = BD.InsertarAlgo(@"update sis_usuarios set estado = @estado where id_usuario= @id_usuario",parametros);
            MessageBox.Show(exito ? "Usuario dado de baja correctamente." : "Error al dar de baja el usuario.", 
                            exito ? "Éxito" : "Error", 
                            MessageBoxButtons.OK, 
                            exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
            if (exito) { 
                
                llenarTabla();
                limpiarCampos();
                btnGuardar.Enabled = true;
                btnActualizar.Enabled = false;
                btnBaja.Enabled = false;
            }
        }
    }
}
