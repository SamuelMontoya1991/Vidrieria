using System;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Empresa
{
    public partial class InformacionEmpresa : Form, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Tema temaActual;
        public InformacionEmpresa()
        {
            InitializeComponent();
            //llenarCampos();
        }

        private void InformacionEmpresa_Load(object sender, EventArgs e)
        {
            string cuenta = BD.devolverUnValor("select count(*) from sis_empresa");

            if (cuenta.Equals("0"))
            {
                administrarCampos(true);
            }
            else
            {
                btnGuardar.Enabled = false;
                btnActualizar.Enabled = true;
                llenarCampos();
            }

        }

        //por default sera true
        private void administrarCampos(bool opcion)
        {
            txtNombre.ReadOnly = opcion;
            txtDireccion.ReadOnly = opcion;
            txtTelefono.ReadOnly = opcion;
            txtCorreo.ReadOnly = opcion;
            txtEslogan.ReadOnly = opcion;
            txtRTN.ReadOnly = opcion;
            txtEncabezado.ReadOnly = opcion;
            txtEncabezado2.ReadOnly = opcion;
            txtNota.ReadOnly = opcion;
            btnGuardar.Enabled = opcion;
            btnActualizar.Enabled = !opcion;
        }

        private void llenarCampos()
        {
            ModeloEmpresa empresa = new ModeloEmpresa();
            empresa = BD.ObtenerEmpresa();
            txtNombre.Text = empresa.nombre;
            txtDireccion.Text = empresa.direccion;
            txtTelefono.Text = empresa.telefono;
            txtCorreo.Text = empresa.correo;
            txtRTN.Text = empresa.RTN;
            txtEncabezado.Text = empresa.encabezado;
            txtEncabezado2.Text = empresa.encabezado2;
            txtEslogan.Text = empresa.eslogan;
            txtNota.Text = empresa.nota;

        }
        private void Guardar()
        {
            ModeloEmpresa empresa = new ModeloEmpresa(
                id_empresa: BD.devolverUnValor("select isnull(max(id_empresa),1) from sis_empresa"),
                nombre: txtNombre.Text,
                direccion: txtDireccion.Text,
                telefono: txtTelefono.Text,
                correo: txtCorreo.Text,
                RTN: txtRTN.Text,
                encabezado: txtEncabezado.Text,
                encabezado2: txtEncabezado2.Text,
                eslogan: txtEslogan.Text,
                nota: txtNota.Text
                );

            bool isSaved = BD.InsertarEmpresa(empresa);

            MessageBox.Show(isSaved ? "Empresa guardada correctamente." : "Error al guardar la empresa.",
                            "Información",
                            MessageBoxButtons.OK,
                            isSaved ? MessageBoxIcon.Information : MessageBoxIcon.Error);

        }
        private bool validarCampos()
        {
            return !string.IsNullOrEmpty(txtNombre.Text) ||
                   !string.IsNullOrEmpty(txtDireccion.Text) ||
                   !string.IsNullOrEmpty(txtTelefono.Text) ||
                   !string.IsNullOrEmpty(txtCorreo.Text) ||
                   !string.IsNullOrEmpty(txtRTN.Text) ||
                   !string.IsNullOrEmpty(txtEncabezado.Text) ||
                   !string.IsNullOrEmpty(txtEncabezado2.Text) ||
                   !string.IsNullOrEmpty(txtEslogan.Text) ||
                   !string.IsNullOrEmpty(txtNota.Text);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string cuenta = BD.devolverUnValor("select count(*) from sis_empresa");
            if (cuenta.Equals("0") && validarCampos())
            {
                Guardar();
                llenarCampos();
            }
            else
            {
                ModeloEmpresa empresa = new ModeloEmpresa(
                id_empresa: BD.devolverUnValor("select isnull(max(id_empresa),1) from sis_empresa"),
                nombre: txtNombre.Text,
                direccion: txtDireccion.Text,
                telefono: txtTelefono.Text,
                correo: txtCorreo.Text,
                RTN: txtRTN.Text,
                encabezado: txtEncabezado.Text,
                encabezado2: txtEncabezado2.Text,
                eslogan: txtEslogan.Text,
                nota: txtNota.Text
                );

                bool isSaved = BD.ActualizarEmpresa(empresa);
                MessageBox.Show(isSaved ? "Empresa actualizada correctamente." : "Error al actualizar la empresa.",
                           "Información",
                           MessageBoxButtons.OK,
                           isSaved ? MessageBoxIcon.Information : MessageBoxIcon.Error);

                llenarCampos();
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            txtNombre.ReadOnly = false;
            txtDireccion.ReadOnly = false;
            txtTelefono.ReadOnly = false;
            txtCorreo.ReadOnly = false;
            txtEslogan.ReadOnly = false;
            txtRTN.ReadOnly = false;
            txtEncabezado.ReadOnly = false;
            txtEncabezado2.ReadOnly = false;
            txtNota.ReadOnly = false;
            btnGuardar.Enabled = true;
            btnActualizar.Enabled = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            string cuenta = BD.devolverUnValor("SELECT COUNT(*) FROM sis_cai");

            if (cuenta == "0")
            {
                DialogResult decision = MessageBox.Show(
                    "Aún no ha ingresado la información de la facturación, ¿desea hacerlo ahora?",
                    "Decisión",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (decision == DialogResult.Yes)
                {
                    //InformacionFactura form = new InformacionFactura();
                    //CentrarVentanaInterna(form); // Este método lo defines tú si usas MDI
                    //this.Close(); // o this.Dispose() si prefieres liberar recursos
                }
            }
            else
            {
                this.Close();
            }
        }

        private void txtNombre_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtDireccion.Focus();
            }
        }

        private void txtDireccion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtTelefono.Focus();
            }
        }

        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtCorreo.Focus();
            }
        }

        private void txtCorreo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEncabezado.Focus();
            }
        }

        private void txtEncabezado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEncabezado2.Focus();
            }
        }

        private void txtEncabezado2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtEslogan.Focus();
            }
        }

        private void txtEslogan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRTN.Focus();
            }
        }

        private void txtRTN_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtNota.Focus();
            }
        }

        private void txtNota_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnGuardar.Focus();
            }
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
