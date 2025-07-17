using System;
using System.Collections.Generic;

namespace Vidrieria.Modelos
{
    public class Cotizacion
    {
        public int IdCotizacion { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime? Fecha { get; set; }
        public int EmpresaId { get; set; }
        public int IdVendedor { get; set; }
        public string? Observaciones { get; set; }
        public int? Factura { get; set; }


        public Cotizacion(int idCotizacion, int clienteId, int usuarioId, int empresaId, int idEmpleado, string? observaciones, int? factura, DateTime? fecha = null)
        {
            IdCotizacion = idCotizacion;
            ClienteId = clienteId;
            UsuarioId = usuarioId;
            Fecha = fecha;
            EmpresaId = empresaId;
            IdVendedor = idEmpleado;
            Observaciones = observaciones;
            Factura = factura;
        }

        override public string ToString()
        {
            return $"Id: {IdCotizacion}, Cliente: {ClienteId}, Fecha: {Fecha}, Vendedor: {IdVendedor}";
        }
    }

    public class DetalleCotizacion
    {
        public int IdCotizacion { get; set; }
        public int IdTrabajo { get; set; }
        public string Medidas { get; set; }
        public string? Descripcion { get; set; }
        public decimal Area { get; set; }
        public int Cantidad { get; set; }
        public decimal Precio { get; set; }
        public decimal Costo { get; set; }
        public string Color { get; set; } = "Natural";


        public DetalleCotizacion(int idCotizacion, int idTrabajo, string medidas, decimal area, int cantidad, decimal precio, decimal costo, string color = "Natural", string descripcion = "")
        {
            IdCotizacion = idCotizacion;
            IdTrabajo = idTrabajo;
            Descripcion = descripcion;
            Medidas = medidas;
            Area = area;
            Cantidad = cantidad;
            Precio = precio;
            Costo = costo;
            Color = color;
        }

        override public string ToString()
        {
            return $"IdCotizacion: {IdCotizacion}, IdTrabajo: {IdTrabajo}, Medidas: {Medidas}, Area: {Area}, Cantidad: {Cantidad}, Precio: {Precio}, Costo: {Costo}, Color: {Color}";
        }
    }

    public class MaterialesUsados
    {
        public int IdCotizacion { set; get; }
        public string? NombreTrabajo { set; get; }
        public string? Descripcion { set; get; }
        public decimal Utilizado { set; get; }
        public int id_trabajo { set; get; }
    }

    public class CotizacionCompleta
    {

        public Cotizacion Cotizacion { get; set; }
        public List<DetalleCotizacion> Detalles { get; set; } = new List<DetalleCotizacion>();
        public List<MaterialesUsados> MaterialesUsados { get; set; } = new List<MaterialesUsados>();

        public CotizacionCompleta(Cotizacion cotizacion, List<DetalleCotizacion> detalles, List<MaterialesUsados> materialesUsados)
        {
            Cotizacion = cotizacion;
            Detalles = detalles;
            MaterialesUsados = materialesUsados;
        }

        override public string ToString()
        {
            return $"Cotizacion: {Cotizacion}, Detalles: {Detalles.Count}, Materiales Usados: {MaterialesUsados.Count}";
        }
    }


}
