using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Clientes;
using Vidrieria.Formularios.Empresa;
using Vidrieria.Formularios.Factura;
using Vidrieria.Formularios.Gastos;
using Vidrieria.Formularios.Login;
using Vidrieria.Formularios.Materiales;
using Vidrieria.Formularios.ReportesEnSistema;
using Vidrieria.Formularios.Trabajos;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.MenuPrincipal
{
    public partial class MenuPrincipalForm : Form
    {
        public Usuario? usuario;
        private ConexionDB BD = new ConexionDB();

        Tema temaActual;

        public MenuPrincipalForm(Tema tema, Usuario usu)
        {
            InitializeComponent();
            this.temaActual = tema;
            AplicarTema(tema);
            this.usuario = usu;
            
            
            SesionInactividad.IniciarControl(this);
            var vencidas = BD.ObtenerFacturasVencidas();
            if (vencidas.Any())
            {
                this.MostrarNotificacionesFacturas(vencidas);
            }
        }

        public void MostrarNotificacionesFacturas(List<FacturaVencida> facturas)
        {
            int offset = 0;

            foreach (var f in facturas)
            {
                string mensaje = $"Factura #{f.IDFactura}\nCliente: {f.Cliente}\nVencida hace {f.diasVencidos} días\nTotal: L.{f.Total:N2}";
                var toast = new ToastNotificationForm(mensaje);

                Point pos = this.PointToScreen(Point.Empty);
                int x = pos.X + this.ClientSize.Width - toast.Width - 20;
                int y = pos.Y + this.ClientSize.Height - toast.Height - 20 - offset;

                toast.Location = new Point(x, y);
                toast.Show();

                offset += toast.Height + 10; // Stack las notificaciones
            }
        }




        public void AbrirFormularioCentrado<T>(Usuario? usuario = null, List<NuevoTrabajo>? trabajos = null, int idCotizacion=0, FacturaCompleta factura=null, Tema tema=Tema.Claro ) where T : Form, new()
        {
            Form? formExistente = this.MdiChildren.FirstOrDefault(f => f is T);
            if (formExistente == null)
            {
                T form = new T();
                form.MdiParent = this;
                form.StartPosition = FormStartPosition.Manual;

                // Centrar el formulario
                int ancho = this.ClientSize.Width;
                int alto = this.ClientSize.Height;
                int anchoForm = form.Width;
                int altoForm = form.Height;
                form.Location = new Point((ancho - anchoForm) / 2, (alto - altoForm) / 2);

                // Inicializar interfaces si el formulario las implementa
                if (form is IFormularioConUsuario formularioConUsuario && usuario != null)
                {
                    formularioConUsuario.InicializarUsuario(usuario);
                }

                if (form is IFormularioConTrabajo formularioConTrabajo && trabajos != null)
                {
                    formularioConTrabajo.InicializarTrabajos(trabajos);
                }

                if (form is IFormularioConCotizacion formularioConCotizacion && idCotizacion !=0)
                {
                    formularioConCotizacion.InicializarCotizacion(idCotizacion);
                }
                if (form is IFormularioConFactura formularioConFactura && factura != null)
                {
                    formularioConFactura.InicializarFactura(factura);
                }
                if (form is IFormularioConTema formularioConTema)
                {
                    formularioConTema.AplicarTema(TemaDeApp.TemaActual);
                }

                form.Show();
            }
            else
            {
                formExistente.BringToFront();
            }
        }

        private void administrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<AdministrarClientes>();
        }

        private void salirDelSistemaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
                "¿Está seguro que desea salir del sistema?",
                "Confirmación de salida",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            if (resultado == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void cerrarSesiónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult resultado = MessageBox.Show(
            "¿Desea cerrar sesión?",
            "Confirmar cierre de sesión",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
    );

            if (resultado == DialogResult.Yes)
            {
                this.Close();
                LoginForm loginForm = new LoginForm();
                loginForm.Show();
            }
        }

        private void informacionEmpresaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<InformacionEmpresa>(null,null,0,null,this.temaActual);
        }

        private void informaciónFacturaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<InformacionFactura>(this.usuario, null, 0, null, this.temaActual);
        }

        private void reporteGToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<ReporteGastos>(this.usuario,null,0,null,this.temaActual);
        }

        private void nuevoGastoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<NuevoGasto>(this.usuario,null,0,null,this.temaActual);
        }

        private void accesoriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<ControlMateriales>(this.usuario, null, 0, null, this.temaActual);
        }

        private void administrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<AdministrarUsuarios>(this.usuario, null, 0, null, this.temaActual);
        }

        private void trabajosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<TrabajosForm>(this.usuario,null,0,null,temaActual);
        }

        private void reporteCotizacionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<ReporteCotizaciones>(this.usuario, null, 0, null, this.temaActual);
        }

        private void empleadosToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void trabajosPersonalizadosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioCentrado<CalculosPersonalizados>(this.usuario, null, 0, null, temaActual);
        }

        private void claroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (TemaDeApp.TemaActual == Tema.Claro)
            {
                MessageBox.Show("El tema ya está configurado como claro.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            temaActual = Tema.Claro;
            TemaDeApp.CambiarTema(temaActual);
            temaClaro.Checked = true;
            temaOscuro.Checked = false;
            EstilosControles.AplicarEstiloFormulario(this);
        }

        private void oscuroToolStripMenuItem_Click(object sender, EventArgs e)
        {
            temaActual = Tema.Oscuro;
            temaOscuro.Checked = true;
            temaClaro.Checked = false;
            TemaDeApp.CambiarTema(temaActual);
            EstilosControles.AplicarEstiloFormulario(this);
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

        
    }

}
