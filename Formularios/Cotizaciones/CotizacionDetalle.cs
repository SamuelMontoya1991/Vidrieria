using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Factura;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Cotizaciones
{
    public partial class CotizacionDetalle : Form, IFormularioConUsuario, IFormularioConCotizacion, IFormularioConTema
    {

        CotizacionCompleta? cotizacionCompleta;
        Usuario? Usuario;
        Tema temaActual;
        ConexionDB BD = new ConexionDB();


        private void llenarCotizacion(CotizacionCompleta cotizacionCompleta)
        {
            txtID.Text = cotizacionCompleta.Cotizacion.IdCotizacion.ToString();
            txtFecha.Text = cotizacionCompleta.Cotizacion.Fecha.ToString();
            txtIdCliente.Text = cotizacionCompleta.Cotizacion.ClienteId.ToString();
            txtNombreCliente.Text = BD.devolverUnValor("select nombrecliente from sis_clientes where id_cliente =" + cotizacionCompleta.Cotizacion.ClienteId);
            txtObservaciones.Text = cotizacionCompleta.Cotizacion.Observaciones ?? "No hay observaciones";

            var detallesAMostrar = cotizacionCompleta.Detalles
                                    .Select(d => new
                                    {
                                        d.Descripcion,
                                        d.Medidas,
                                        d.Area,
                                        d.Cantidad,
                                        d.Precio,
                                        Subtotal = d.Cantidad * d.Precio,
                                    })
                                    .ToList();
            tblTrabajos.DataSource = detallesAMostrar;

            decimal suma = 0;
            for (int i = 0; i < tblTrabajos.RowCount; i++)
            {
                decimal precio = 0, cantidad = 0;
                precio = Convert.ToDecimal(tblTrabajos.Rows[i].Cells["Precio"].Value);
                cantidad = Convert.ToDecimal(tblTrabajos.Rows[i].Cells["Cantidad"].Value);
                suma += Convert.ToDecimal(tblTrabajos.Rows[i].Cells["Subtotal"].Value);
            }
            decimal subtotal = suma / 1.15m;
            txtSubtotal.Text = subtotal.ToString("C2");
            txtISV.Text = (suma - subtotal).ToString("C2");
            txtTotal.Text = suma.ToString("C2");


        }

        public CotizacionDetalle()
        {
            InitializeComponent();

        }

        public void InicializarCotizacion(int idCotizacion)
        {

            cotizacionCompleta = BD.obtenerCotizacionCompleta(idCotizacion);
            llenarCotizacion(cotizacionCompleta!);
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.Usuario = usuario;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new ListaMaterialesDialog(cotizacionCompleta!.MaterialesUsados);
            dialog.ShowDialog(this);
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            var padre = this.MdiParent as MenuPrincipalForm;
            if (padre != null)
            {
                int idCotizacion = Convert.ToInt32(txtID.Text);
                padre.AbrirFormularioCentrado<Facturar>(this.Usuario!, null, idCotizacion,null);
            }
        }

        private void btnVerMateriales_Click(object sender, EventArgs e)
        {
            int idCotizacion = Convert.ToInt32(txtID.Text);
            List<MaterialesUsados> materiales = BD.obtenerMaterialesUsados(idCotizacion);
            if (materiales.Count > 0)
            {
                var dialog = new ListaMaterialesDialog(materiales);
                dialog.ShowDialog(this);
            }
            else
            {
                MessageBox.Show("No hay materiales usados en esta cotización.");
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
