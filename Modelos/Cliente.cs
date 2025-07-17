namespace Vidrieria.Modelos
{
    public class Cliente
    {
        public string IdCliente;
        public string NombreCliente;
        public string Identidad;
        public string Rtn;
        public string Direccion;
        public string Telefono;
        public string Correo;

        public Cliente(string idCliente, string nombreCliente, string identidad, string rtn, string direccion, string telefono, string correo)
        {
            this.IdCliente = idCliente;
            this.NombreCliente = nombreCliente;
            this.Identidad = identidad;
            this.Rtn = rtn;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }
        public Cliente() { }

    }
}
