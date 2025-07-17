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

namespace Vidrieria.Formularios.Factura
{
    public partial class Cobros : Form, IFormularioConFactura, IFormularioConUsuario, IFormularioConTema
    {
        private ConexionDB BD = new ConexionDB();
        private FacturaCompleta factura;
        private Usuario usuario;
        Tema temaActual;
        private NumerosEnLetras letras = new NumerosEnLetras();

        public Cobros()
        {
            InitializeComponent();
            InicializarComboTipoPago();
            txtRecibido.Focus();
        }



        public void InicializarFactura(FacturaCompleta factura)
        {
            this.factura = factura;

            decimal total = factura.formaPago.Subtotal + factura.formaPago.ISV;
            txtTotal.Text = total.ToString("C2");
            lblLetras.Text = letras.Convertir(txtTotal.Text, true);
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void InicializarComboTipoPago()
        {
            cmbTipo.DisplayMember = "descripcion";
            cmbTipo.DataSource = BD.llenarCombobox(
                "SELECT descripcionPago AS descripcion FROM sis_tipo_pago",
                "-Seleccione tipo de pago-"
            );
        }

        private bool ValidarCampos()
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                MostrarError("Debe seleccionar un tipo de pago.");
                cmbTipo.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtRecibido.Text))
            {
                MostrarError("Debe ingresar un monto recibido.");
                txtRecibido.Focus();
                return false;
            }

            if (!decimal.TryParse(txtRecibido.Text.Replace("L", "").Replace(",", "").Trim(), out decimal recibido))
            {
                MostrarError("El monto recibido no es válido.");
                txtRecibido.Focus();
                return false;
            }

            decimal total = ObtenerTotalDecimal();
            if (recibido < total)
            {
                MostrarError("El monto recibido no puede ser menor al total.");
                txtRecibido.Focus();
                return false;
            }

            return true;
        }


        private void MostrarError(string mensaje)
        {
            MessageBox.Show(mensaje, "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }



        private void CalcularCambio()
        {
            try
            {
                decimal recibido = Convert.ToDecimal(txtRecibido.Text);
                decimal total = ObtenerTotalDecimal();

                decimal cambio = recibido - total;
                txtCambio.Text = cambio.ToString("C2");

                txtCambio.ForeColor = cambio >= 0 ? Color.Green : Color.Red;
                btnGuardar.Enabled = cambio >= 0;
            }
            catch (FormatException)
            {
                txtCambio.Text = "Error";
                txtCambio.ForeColor = Color.Red;
                btnGuardar.Enabled = false;
            }
        }

        private decimal ObtenerTotalDecimal()
        {
            return Convert.ToDecimal(txtTotal.Text.Replace("L", "").Replace(",", "").Trim());
        }



        private void cmbTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipo.SelectedIndex == 0)
            {
                btnGuardar.Enabled = false;
                return;
            }
            else {
                factura.formaPago.TipoPago = cmbTipo.SelectedIndex;
                txtRecibido.Focus();
                btnGuardar.Enabled = true;
            }
        }

        private void txtRecibido_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRecibido.Text))
            {
                CalcularCambio();
            }
        }

        private void txtRecibido_Enter(object sender, EventArgs e)
        {
            ((TextBox)sender).SelectAll();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (ValidarCampos())
            {
                int idFactura = Convert.ToInt32(BD.devolverUnValor("select isnull(max(id_factura+1),1) from sis_factura"));
                BD.ReemplazarValorEnListas(factura.Detalles, "IDFactura", idFactura);
                decimal subtotal = Convert.ToDecimal(txtTotal.Text.Replace("L", "").Replace(",", "").Trim()) / 1.15m;
                factura.Factura.IDFactura = idFactura;
                factura.formaPago.IDFactura = idFactura;
                factura.formaPago.TipoPago = cmbTipo.SelectedIndex;
                factura.formaPago.cambio = Convert.ToDecimal(txtCambio.Text.Replace("L", "").Replace(",", "").Trim());
                factura.formaPago.Subtotal = subtotal;
                factura.formaPago.ISV = Convert.ToDecimal(txtTotal.Text.Replace("L", "").Replace(",", "").Trim()) - factura.formaPago.Subtotal;

                bool exito = BD.InsertarFacturaCompleta(factura);
                if (exito)
                {
                    MessageBox.Show("Factura registrada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    var facturar = this.MdiParent?.MdiChildren
                        .FirstOrDefault(f => f is Facturar);

                    if (facturar != null)
                        facturar.Close();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Error al registrar la factura. Intente nuevamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, debe llenar los campos necesarios antes de guardar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtRecibido_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                    CalcularCambio();
                    btnGuardar.Focus();
                    e.SuppressKeyPress = true;
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
