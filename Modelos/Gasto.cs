using System;

namespace Vidrieria.Modelos
{
    public class TipoGasto
    {
        public int? id { get; set; }
        public string? tipoGasto { get; set; }
        public decimal? cantidad { get; set; }
        public string? observacion { get; set; }
        public string? documento { get; set; }
        public DateTime? fechaCompra { get; set; }
        public int idUsuario { get; set; }


        public TipoGasto() { }

        public TipoGasto(int? id, string? tipoGasto, decimal? cantidad, string? observacion, string? documento, DateTime? fechaCompra, int idUsuario)
        {
            this.id = id;
            this.tipoGasto = tipoGasto;
            this.cantidad = cantidad;
            this.observacion = observacion;
            this.documento = documento;
            this.fechaCompra = fechaCompra;
            this.idUsuario = idUsuario;
        }

        override
        public string ToString()
        {
            return $"ID: {this.id}, " +
                $"TipoGasto: {this.tipoGasto}, " +
                $"Cantidad: {this.cantidad}, " +
                $"Observacion: {this.observacion}, " +
                $"Documento: {this.documento}, " +
                $"FechaCompra: {this.fechaCompra}, "+
                $"idUsuario: {this.idUsuario}";
        }


    }
}
