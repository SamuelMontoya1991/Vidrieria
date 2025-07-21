using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidrieria.Modelos
{
    public class NuevoProveedor
    {
        public string IdProveedor;
        public string NombreProveedor;
        public string Identidad;
        public string Rtn;
        public string Direccion;
        public string Telefono;
        public string Correo;

        public NuevoProveedor(string idProveedor, string nombreProveedor, string identidad, string rtn, string direccion, string telefono, string correo)
        {
            this.IdProveedor = idProveedor;
            this.NombreProveedor = nombreProveedor;
            this.Identidad = identidad;
            this.Rtn = rtn;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Correo = correo;
        }
        public NuevoProveedor() { }

    }
}
