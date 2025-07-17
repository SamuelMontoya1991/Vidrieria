using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidrieria.Modelos
{
    public class NuevaFactura
    {
        public int IDFactura { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int EmpresaId { get; set; }
        public int IdCai { get; set; }
        public int VendedorId { get; set; }
        public int RTN { get; set; }
        public int TipoPago { get; set; } 
        public int IdCotizacion { get; set; } 
        public int? Estado { get; set; } = 0;
        public int? Pagado { get; set; } = 0;

        public NuevaFactura() { }
        public NuevaFactura(int id, int clienteId, int usuarioId,int empresaId, int vendedorId, int tipoFactura, int cai, int tipoPago, int idCotizacion, int idCai, int estado,int pagado)
        {
            IDFactura = id;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            EmpresaId = empresaId;
            VendedorId = vendedorId;
            RTN = tipoFactura;
            TipoPago = tipoPago;
            IdCotizacion = idCotizacion;
            IdCai = idCai;
            Estado = estado;
            Pagado = pagado;
        }
        public override string ToString()
        {
            return $"Factura ID: {IDFactura}, Cliente ID: {ClienteId}, Usuario ID: {UsuarioId}, Vendedor ID: {VendedorId}, Tipo Factura: {RTN}, Tipo Pago: {TipoPago}, Cotizacion ID: {IdCotizacion}, id_Cai: {IdCai}";
        }
    }

    public class FacturaDetalle {

        public int IDFactura { get; set; }
        public int IdTrabajo { get; set; }
        public string Medidas { get; set; }
        public string? Descripcion { get; set; }
        public decimal Area { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public string Color { get; set; } = "Natural";

        public FacturaDetalle(int idFactura, int idTrabajo, string medidas, decimal area, int cantidad, decimal precio, decimal costo, string color = "Natural", string descripcion = "")
        {
            IDFactura = idFactura;
            IdTrabajo = idTrabajo;
            Descripcion = descripcion;
            Medidas = medidas;
            Area = area;
            Cantidad = cantidad;
            Precio = precio;
            Costo = costo;
            Color = color;
        }
        public FacturaDetalle() { }
        public override string ToString()
        {
            return $"Factura ID: {IDFactura}, Trabajo ID: {IdTrabajo}, Medidas: {Medidas}, Area: {Area}, Cantidad: {Cantidad}, Precio: {Precio}, Costo: {Costo}, Color: {Color}";
        }
    }

    public class FormaPago
    {
        public int IDFactura { get; set; }
        public int TipoPago { get; set; }
        public decimal Subtotal { get; set; }
        public decimal ISV { get; set; }
        public decimal cambio { get; set; }
        public FormaPago(int facturaID, int tipoPago, decimal subtotal, decimal isv, decimal cambio)
        {
            IDFactura = facturaID;
            TipoPago = tipoPago;
            Subtotal = subtotal;
            ISV = isv;
            this.cambio = cambio;
        }
        public FormaPago() { }
        public override string ToString()
        {
            return $"Factura ID: {IDFactura}, Tipo Pago: {TipoPago}, Subtotal: {Subtotal}, ISV: {ISV}, Cambio: {cambio}";
        }
    }
    public class FacturaCompleta
    {
        public NuevaFactura Factura { get; set; }
        public List<FacturaDetalle> Detalles { get; set; }
        public FormaPago formaPago { get; set; }
        public FacturaCompleta(NuevaFactura factura, List<FacturaDetalle> detalles, FormaPago formaPago)
        {
            Factura = factura;
            Detalles = detalles;
            this.formaPago = formaPago;
        }
        public override string ToString()
        {
            return $"Factura: {Factura}, Detalles: {Detalles.Count}, Forma de Pago: {formaPago}";
        }
    }

    public class FacturaVencida {
        public int IDFactura { get; set; }
        public string Cliente { get; set; }
        public int diasVencidos { get; set; }
        public decimal Total { get; set; }

        public FacturaVencida(int idFactura, string cliente, int diasVencidos, decimal total)
        {
            IDFactura = idFactura;
            Cliente = cliente;
            this.diasVencidos = diasVencidos;
            Total = total;
        }
        public FacturaVencida() { }
        public override string ToString()
        {
            return $"Factura ID: {IDFactura}, Cliente: {Cliente}, Días Vencidos: {diasVencidos}, Total: {Total}";
        }
    }
}
