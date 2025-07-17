using System.Collections.Generic;
using Vidrieria.Clases;
using Vidrieria.Clases.ClasesTrabajos;
using Vidrieria.Modelos;

namespace Vidrieria.Interfaces
{
    public interface IFormularioConUsuario
    {
        void InicializarUsuario(Usuario usuario);
    }

    public interface IFormularioConTrabajo
    {
        void InicializarTrabajos(List<NuevoTrabajo> trabajos);
    }
    public interface IFormularioConCotizacion
    {
        void InicializarCotizacion(int idCotizacion);
    }
    public interface IFormularioConFactura
    {
        void InicializarFactura(FacturaCompleta factura);
    }
    public interface IFormularioConTema
    {
        void AplicarTema(Tema tema);
    }

}
