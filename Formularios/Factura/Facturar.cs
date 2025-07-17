using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.MenuPrincipal;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Factura
{
    public partial class Facturar : Form, IFormularioConUsuario, IFormularioConCotizacion, IFormularioConTrabajo, IFormularioConTema
    {
        public Usuario? Usuario { get; set; }
        public CotizacionCompleta? CotizacionCompleta { get; set; }
        ConexionDB BD = new ConexionDB();
        int RTN = 0, TipoFactura=0;
        Tema temaActual;
        List<NuevoTrabajo> listaTrabajos = new List<NuevoTrabajo>();


        private void llenarFactura(CotizacionCompleta cotizacionCompleta)
        {
            
            
            txtClienteID.Text = cotizacionCompleta.Cotizacion.ClienteId.ToString();
            txtNombreCliente.Text = BD.devolverUnValor("select nombrecliente from sis_clientes where id_cliente =" + cotizacionCompleta.Cotizacion.ClienteId);
            txtVendedorID.Text = cotizacionCompleta.Cotizacion.IdVendedor.ToString();
            txtNombreVendedor.Text = BD.devolverUnValor("select nombrevendedor from sis_vendedores where id_vendedor =" + cotizacionCompleta.Cotizacion.IdVendedor);

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
        public void LlenarTrabajos(List<NuevoTrabajo> trabajos)
        {
            DataTable dtTrabajos = new DataTable();
            dtTrabajos.Columns.Add("descripcion", typeof(string));
            dtTrabajos.Columns.Add("medidas", typeof(string));
            dtTrabajos.Columns.Add("cantidad", typeof(int));
            dtTrabajos.Columns.Add("precio", typeof(decimal));
            dtTrabajos.Columns.Add("subtotal", typeof(decimal));

            tblTrabajos.AutoGenerateColumns = false;
            tblTrabajos.Columns["descripcion"].DisplayIndex = 0;
            tblTrabajos.Columns["medidas"].DisplayIndex = 1;
            tblTrabajos.Columns["cantidad"].DisplayIndex = 2;
            tblTrabajos.Columns["precio"].DisplayIndex = 3;
            tblTrabajos.Columns["subtotal"].DisplayIndex = 4;

            tblTrabajos.DataSource = dtTrabajos;

            int contador = 0;
            int filas = trabajos.Count;

            while (contador < filas)
            {
                decimal precioUnitario = Convert.ToDecimal(
                                trabajos[contador].PrecioSeleccionado!.Value / trabajos[contador].Cantidad!.Value);
                decimal total = Convert.ToDecimal(trabajos[contador].PrecioSeleccionado!.Value);

                dtTrabajos.Rows.Add(
                    trabajos[contador].Nombre!,
                    $"{trabajos[contador].Ancho}x{trabajos[contador].Alto}",
                    trabajos[contador].Cantidad!.Value,
                    precioUnitario,
                    total
                );
                contador++;
            }
            calcularTotales();
            txtClienteID.Focus();
        }
        private void calcularTotales()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in tblTrabajos.Rows)
            {
                if (row.Cells["subtotal"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["subtotal"].Value);
                }
            }
            decimal subtotal = total / 1.15m;
            txtSubtotal.Text = subtotal.ToString("C2");
            txtISV.Text = (total - subtotal).ToString("C2");
            txtTotal.Text = total.ToString("C2");
        }



        public Facturar()
        {
            InitializeComponent();
            rdConsumidor.Checked = true;
            rdContado.Checked = true;
        }

        private void rdRTN_CheckedChanged(object sender, EventArgs e)
        {
            if (rdRTN.Checked)
            {
                rdConsumidor.Checked = false;
                RTN = 1;
            }
        }
        private bool ValidarCampos()
        {
            if (string.IsNullOrWhiteSpace(txtClienteID.Text))
            {
                MessageBox.Show("Debe ingresar un cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtClienteID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreCliente.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtVendedorID.Text))
            {
                MessageBox.Show("Debe ingresar el código del vendedor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtVendedorID.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtNombreVendedor.Text))
            {
                MessageBox.Show("Debe ingresar el nombre del vendedor.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtNombreVendedor.Focus();
                return false;
            }

            if (tblTrabajos.Rows.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un trabajo.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTotal.Text) || txtTotal.Text == "L 0.00")
            {
                MessageBox.Show("El total no puede ser cero.", "Total inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }


        public void InicializarUsuario(Usuario usuario)
        {
            this.Usuario = usuario;
        }

        public void InicializarCotizacion(int idCotizacion)
        {
            this.CotizacionCompleta = BD.obtenerCotizacionCompleta(idCotizacion);
            llenarFactura(CotizacionCompleta);
        }

        private void tblClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string consulta = "SELECT id_cliente FROM sis_Clientes WHERE nombrecliente = '" + tblClientes.CurrentRow.Cells[0].Value.ToString() + "'";
            string codigo = BD.devolverUnValor(consulta);
            if (!string.IsNullOrEmpty(codigo))
            {
                txtClienteID.Text = codigo;
                txtNombreCliente.Text = tblClientes.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text.Equals(""))
            {
                string consulta = "select nombrecliente from sis_clientes";
                DataTable datos = BD.LlenarTabla(consulta);
                tblClientes.DataSource = datos;
            }
            else
            {
                string consulta = "select nombrecliente from sis_clientes where nombrecliente like '%" + txtNombreCliente.Text + "%'";
                DataTable datos = BD.LlenarTabla(consulta);
                tblClientes.DataSource = datos;
            }
        }

        private void txtClienteID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (e.KeyCode == Keys.Enter)
                    {
                        string consulta = "SELECT count(NombreCliente) FROM sis_Clientes WHERE Id_Cliente = " + txtClienteID.Text.Trim() + "";
                        string nombreCliente = BD.devolverUnValor(consulta);
                        if (nombreCliente.Equals("1"))
                        {
                            consulta = "SELECT NombreCliente FROM sis_Clientes WHERE Id_Cliente = " + txtClienteID.Text.Trim() + "";
                            nombreCliente = BD.devolverUnValor(consulta);
                            if (!string.IsNullOrEmpty(nombreCliente))
                            {
                                txtNombreCliente.Text = nombreCliente;
                                txtVendedorID.Focus();
                            } 
                        }
                        else
                        {
                            MessageBox.Show("El cliente no existe. Por favor, verifique el código ingresado.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtClienteID.Clear();
                            txtNombreCliente.Clear();
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void txtClienteID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rdContado_CheckedChanged(object sender, EventArgs e)
        {
            if(rdContado.Checked)
            {
                rdCredito.Checked = false;
                TipoFactura = 0; 
            }
        }

        private void rdCredito_CheckedChanged(object sender, EventArgs e)
        {
            if (rdCredito.Checked)
            {
                rdContado.Checked = false;
                TipoFactura = 1; 
            }
        }

        private void btnFacturar_Click(object sender, EventArgs e)
        {
            if (ValidarCampos())
            {
                List<FacturaDetalle> detalles = new List<FacturaDetalle>();
                NuevaFactura factura = new NuevaFactura
                {
                    IDFactura = 0,
                    ClienteId = Convert.ToInt32(txtClienteID.Text),
                    UsuarioId = this.Usuario.Id_Usuario,
                    EmpresaId = 1,
                    IdCai = Convert.ToInt32(BD.devolverUnValor("Select isnull(id_cai,1) from sis_cai where estado=1")),
                    VendedorId = txtVendedorID.Text == "" ? 1 : Convert.ToInt32(txtVendedorID.Text),
                    RTN = this.RTN,
                    TipoPago = TipoFactura,
                    IdCotizacion = this.CotizacionCompleta != null ? this.CotizacionCompleta.Cotizacion.IdCotizacion : 0,
                    Pagado = TipoFactura == 0 ? 0 : 1,
                };


                if (CotizacionCompleta != null)
                {
                    foreach (var trabajo in CotizacionCompleta.Detalles)
                    {
                        detalles.Add(new FacturaDetalle(
                            0,
                            trabajo.IdTrabajo,
                            trabajo.Medidas,
                            trabajo.Area,
                            trabajo.Cantidad,
                            trabajo.Precio,
                            trabajo.Costo,
                            trabajo.Color,
                            trabajo.Descripcion
                        ));
                    }
                }
                else {
                    foreach (var trabajo in listaTrabajos)
                    {
                        decimal precioUnitario = Convert.ToDecimal(trabajo.PrecioSeleccionado.Value) / Convert.ToDecimal(trabajo.Cantidad.Value);
                        detalles.Add(new FacturaDetalle(
                            0,
                            trabajo.Id!.Value,
                            $"{trabajo.Ancho}x{trabajo.Alto}",
                            Convert.ToDecimal(trabajo.Area),
                            trabajo.Cantidad.Value,
                            precioUnitario,
                             Convert.ToDecimal(trabajo.CostoSeleccionado),
                            trabajo.ColorSeleccionado ?? "Natural",
                            trabajo.Nombre ?? ""
                        ));
                    }
                }


                    FormaPago formaPago = new FormaPago(
                         0,
                         0,
                         Convert.ToDecimal(txtSubtotal.Text.Replace("L", "").Replace(",", "")),
                         Convert.ToDecimal(txtISV.Text.Replace("L", "").Replace(",", "")),
                         0
                        );
                FacturaCompleta facturaCompleta = new FacturaCompleta
                (
                    factura,
                    detalles,
                    formaPago
                );
                var padre = this.MdiParent as MenuPrincipalForm;
                if (padre != null)
                {
                    padre.AbrirFormularioCentrado<Cobros>(this.Usuario, null, 0, facturaCompleta);
                }
            }
            else
            {
                MessageBox.Show("Por favor, complete todos los campos requeridos.", "Campos incompletos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void txtVendedorID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string consulta = "SELECT count(nombreVendedor) FROM sis_vendedores WHERE Id_Vendedor = " + txtVendedorID.Text.Trim() + "";
                string nombreVendedor = BD.devolverUnValor(consulta);
                if (nombreVendedor.Equals("1"))
                {
                    consulta = "SELECT nombreVendedor FROM sis_vendedores WHERE id_vendedor = " + txtVendedorID.Text.Trim() + "";
                    nombreVendedor = BD.devolverUnValor(consulta);
                    if (!string.IsNullOrEmpty(nombreVendedor))
                    {
                        txtNombreVendedor.Text = nombreVendedor;
                        btnFacturar.Focus();
                    }
                }
                else
                {
                    MessageBox.Show("El Vendedor no existe. Por favor, verifique el código ingresado.", "Vendedor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtVendedorID.Clear();
                    txtNombreVendedor.Clear();
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void rdConsumidor_CheckedChanged(object sender, EventArgs e)
        {
            if (rdConsumidor.Checked)
            {
                rdRTN.Checked = false;
                RTN = 0;
            }
        }

        public void InicializarTrabajos(List<NuevoTrabajo> trabajos)
        {
            listaTrabajos = trabajos;
            LlenarTrabajos(trabajos);
            
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(temaActual);
            EstilosControles.AplicarEstiloFormulario(this);
        }
    }
}
