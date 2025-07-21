using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Clases.Buscadores;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Formularios.Clientes;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Cotizaciones
{
    public partial class NuevaCotizacion : Form, IFormularioConUsuario, IFormularioConTrabajo, IFormularioConTema
    {
        ConexionDB BD = new ConexionDB();
        Usuario usuario = new Usuario();
        List<NuevoTrabajo> listaTrabajos = new List<NuevoTrabajo>();
        List<MaterialesUsados> materialesUsados = new List<MaterialesUsados>();
        List<DetalleCotizacion> detalles = new List<DetalleCotizacion>();
        Tema temaActual;
        


        private void calcularTotales()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in tblTrabajos.Rows)
            {
                if (row.Cells["total"].Value != null)
                {
                    total += Convert.ToDecimal(row.Cells["total"].Value);
                }
            }
            txtTotal.Text = total.ToString("C2");
        }
        public void LlenarTrabajos(List<NuevoTrabajo> trabajos)
        {
            DataTable dtTrabajos = new DataTable();
            dtTrabajos.Columns.Add("descripcion", typeof(string));
            dtTrabajos.Columns.Add("medidas", typeof(string));
            dtTrabajos.Columns.Add("cantidad", typeof(int));
            dtTrabajos.Columns.Add("precio", typeof(decimal));
            dtTrabajos.Columns.Add("total", typeof(decimal));

            tblTrabajos.AutoGenerateColumns = false;
            tblTrabajos.Columns["descripcion"].DisplayIndex = 0;
            tblTrabajos.Columns["medidas"].DisplayIndex = 1;
            tblTrabajos.Columns["cantidad"].DisplayIndex = 2;
            tblTrabajos.Columns["precio"].DisplayIndex = 3;
            tblTrabajos.Columns["total"].DisplayIndex = 4;

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
        }
        private bool validarCampos()
        {
            if (string.IsNullOrEmpty(txtCodigoCliente.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese el código del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (string.IsNullOrEmpty(txtNombreCliente.Text.Trim()))
            {
                MessageBox.Show("Por favor, ingrese el nombre del cliente.", "Campo requerido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (listaTrabajos.Count == 0)
            {
                MessageBox.Show("Debe agregar al menos un trabajo a la cotización.", "Sin trabajos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
        private void LimpiarCampos()
        {
            txtCodigoCliente.Clear();
            txtNombreCliente.Clear();
            txtTotal.Clear();
            tblTrabajos.DataSource = null;
            listaTrabajos.Clear();
            txtObservaciones.Clear();
            txtCodigoVendedor.Clear();
            txtNombreVendedor.Clear();

        }
        private Cotizacion obtenerCotizacion(int idCotizacion)
        {
            return new Cotizacion
            (
                idCotizacion,
                Convert.ToInt32(txtCodigoCliente.Text.Trim()),
                this.usuario.Id_Usuario,
                1,//empresa por defecto
                Convert.ToInt32(txtCodigoVendedor.Text.Trim()),
                txtObservaciones.Text.Trim(),
                0//facturado 0 significa no facturado, 1 es facturado
            );




        }
        private void obtenerDetalleCotizacion(int idCotizacion)
        {



            for (int i = 0; i < tblTrabajos.RowCount; i++)
            {
                int cantidad = listaTrabajos[i].Cantidad!.Value;
                decimal precioglobal = Convert.ToDecimal(listaTrabajos[i].PrecioSeleccionado);
                DetalleCotizacion detalle = new DetalleCotizacion
                (
                    idCotizacion,
                    listaTrabajos[i].Id!.Value,
                    listaTrabajos[i].Ancho!.Value.ToString() + "x" + listaTrabajos[i].Alto!.Value.ToString(),
                    Convert.ToDecimal(listaTrabajos[i].Area!.Value),
                    cantidad,
                    Math.Round(precioglobal / cantidad),
                    Convert.ToDecimal(listaTrabajos[i].CostoSeleccionado!),
                    listaTrabajos[i].ColorSeleccionado != null ? listaTrabajos[i].ColorSeleccionado! : "Natural"
                );
                detalles.Add(detalle);

                if (listaTrabajos[i].Aluminio == null)
                {

                }
                else
                {
                    for (int o = 0; o < listaTrabajos[i].Aluminio!.RowCount; o++)
                    {
                        MaterialesUsados materiales = new MaterialesUsados
                        {
                            IdCotizacion = idCotizacion,
                            Descripcion = listaTrabajos[i].Aluminio!.Rows[o].Cells[5].Value.ToString()!,
                            Utilizado = Convert.ToDecimal(listaTrabajos[i].Aluminio!.Rows[o].Cells[6].Value.ToString()!),
                            id_trabajo = Convert.ToInt32(listaTrabajos[i]!.Id)
                        };
                        materialesUsados.Add(materiales);
                    }


                    for (int o = 0; o < listaTrabajos[i].Hoja!.RowCount; o++)
                    {
                        MaterialesUsados materiales = new MaterialesUsados
                        {
                            IdCotizacion = idCotizacion,
                            Descripcion = listaTrabajos[i].Hoja!.Rows[o].Cells[5].Value.ToString()!,
                            Utilizado = Convert.ToDecimal(listaTrabajos[i].Hoja!.Rows[o].Cells[6].Value.ToString()!),
                            id_trabajo = Convert.ToInt32(listaTrabajos[i]!.Id)
                        };
                        materialesUsados.Add(materiales);
                    }

                    for (int o = 0; o < listaTrabajos[i].Moldura!.RowCount; o++)
                    {
                        MaterialesUsados materiales = new MaterialesUsados
                        {
                            IdCotizacion = idCotizacion,
                            Descripcion = listaTrabajos[i].Moldura!.Rows[o].Cells[5].Value.ToString()!,
                            Utilizado = Convert.ToDecimal(listaTrabajos[i].Moldura!.Rows[o].Cells[6].Value.ToString()!),
                            id_trabajo = Convert.ToInt32(listaTrabajos[i]!.Id)
                        };
                        materialesUsados.Add(materiales);
                    }

                    for (int o = 0; o < listaTrabajos[i].Accesorio!.RowCount; o++)
                    {
                        MaterialesUsados materiales = new MaterialesUsados
                        {
                            IdCotizacion = idCotizacion,
                            Descripcion = listaTrabajos[i].Accesorio!.Rows[o].Cells[5].Value.ToString()!,
                            Utilizado = Convert.ToDecimal(listaTrabajos[i].Accesorio!.Rows[o].Cells[6].Value.ToString()!),
                            id_trabajo = Convert.ToInt32(listaTrabajos[i]!.Id)
                        };
                        materialesUsados.Add(materiales);
                    }
                }
            }

        }
        private void Guardar()
        {
            if (validarCampos())
            {
                int idCotizacion = Convert.ToInt32(BD.devolverUnValor("select isnull(max(id_cotizacion+1),1) from sis_cotizaciones"));
                obtenerDetalleCotizacion(idCotizacion);
                CotizacionCompleta cotizacionCompleta = new CotizacionCompleta(
                    obtenerCotizacion(idCotizacion),
                    detalles,
                    materialesUsados
                    );
                bool exito = BD.InsertarCotizacionCompleta(cotizacionCompleta, usuario.Id_Usuario);
                MessageBox.Show(exito ? "Cotización guardada exitosamente." : "Error al guardar la cotización.", "Resultado", MessageBoxButtons.OK, exito ? MessageBoxIcon.Information : MessageBoxIcon.Error);
                if (exito)
                {
                    LimpiarCampos();
                    listaTrabajos.Clear();
                    detalles.Clear();
                    materialesUsados.Clear();
                }
            }
        }

        public NuevaCotizacion()
        {
            InitializeComponent();
        }

        private void txtCodigoCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string consulta = "SELECT NombreCliente FROM sis_Clientes WHERE Id_Cliente = " + txtCodigoCliente.Text.Trim() + "";
                string nombreCliente = BD.devolverUnValor(consulta);
                if (!string.IsNullOrEmpty(nombreCliente))
                {
                    txtNombreCliente.Text = nombreCliente;

                }
                else
                {
                    MessageBox.Show("El cliente no existe. Por favor, verifique el código ingresado.", "Cliente no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoCliente.Clear();
                    txtNombreCliente.Clear();
                }
            }
        }

        private void txtCodigoCliente_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtNombreCliente_TextChanged(object sender, EventArgs e)
        {
            if (txtNombreCliente.Text.Equals(""))
            {
                string consulta = "select nombrecliente from sis_clientes";
                DataTable datos = BD.LlenarTabla(consulta);
                tblCliente.DataSource = datos;
            }
            else
            {
                string consulta = "select nombrecliente from sis_clientes where nombrecliente like '%" + txtNombreCliente.Text + "%'";
                DataTable datos = BD.LlenarTabla(consulta);
                tblCliente.DataSource = datos;
            }
        }

        private void tblCliente_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            string consulta = "SELECT id_cliente FROM sis_Clientes WHERE nombrecliente = '" + tblCliente.CurrentRow.Cells[0].Value.ToString() + "'";
            string codigo = BD.devolverUnValor(consulta);
            if (!string.IsNullOrEmpty(codigo))
            {
                txtCodigoCliente.Text = codigo;
                txtNombreCliente.Text = tblCliente.CurrentRow.Cells[0].Value.ToString();
            }
        }

        private void btnNuevoCliente_Click(object sender, EventArgs e)
        {
            AdministrarClientes adminClientes = new AdministrarClientes();
            adminClientes.ShowDialog();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            Guardar();
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void txtCodigoVendedor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string consulta = "SELECT NombreVendedor FROM sis_vendedores WHERE id_vendedor = " + txtCodigoVendedor.Text.Trim() + "";
                string nombre = BD.devolverUnValor(consulta);
                if (!string.IsNullOrEmpty(nombre))
                {
                    txtNombreVendedor.Text = nombre;

                }
                else
                {
                    MessageBox.Show("El vendedor no existe. Por favor, verifique el código ingresado.", "Vendedor no encontrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtCodigoVendedor.Clear();
                    txtNombreVendedor.Clear();
                }
            }
        }

        public void InicializarTrabajos(List<NuevoTrabajo> lista)
        {
            listaTrabajos = lista;
            LlenarTrabajos(lista);
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            DataTable datosClientes = BD.LlenarTabla("select id_cliente,nombreCliente from sis_clientes"); // o datos simulados
            var buscador = new FormBuscadorGenerico(datosClientes, "Buscar Cliente", "Nombrecliente");

            if (buscador.ShowDialog() == DialogResult.OK)
            {
                txtCodigoCliente.Text = buscador.IdSeleccionado.ToString();
                txtNombreCliente.Text = buscador.NombreSeleccionado;
            }
        }
    }
}
