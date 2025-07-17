using System;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Login
{
    public partial class LoginForm : Form
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual = Tema.Claro;

        public LoginForm()
        {
            InitializeComponent();
            TemaDeApp.CambiarTema(temaActual);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                txtClave.Focus();
            }

            if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                Ingresar();
            }
            if (e.KeyCode == Keys.F4)
            {
                this.Close();
            }
        }

        private void Ingresar()
        {
            try
            {
                if (BD.ValidarLogin(txtUsuario.Text, txtClave.Text))
                {
                    Usuario? usuario = BD.ObtenerUsuarioSiValido(true, txtUsuario.Text);
                    MessageBox.Show("Bienvenid@ " + txtUsuario.Text, "Acceso permitido", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Aquí puedes abrir el formulario principal de la aplicación
                    MenuPrincipalForm formPrincipal = new MenuPrincipalForm(temaActual,usuario!);
                    BD.ActualizarEstadoFacturas();
                    formPrincipal.Show();
                    this.Hide(); // Oculta el formulario de login
                }
                else
                {
                    MessageBox.Show("Usuario o clave incorrectos", "Acceso denegado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtUsuario.Clear();
                    txtClave.Clear();
                    txtUsuario.Focus();
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        
    }
}
