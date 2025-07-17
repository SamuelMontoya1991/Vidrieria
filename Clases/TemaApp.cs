using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vidrieria.Clases
{
    public enum Tema
    {
        Claro,
        Oscuro
    }

    public static class TemaDeApp
    {
        public static Tema TemaActual { get; private set; } = Tema.Claro;

        public static void CambiarTema(Tema nuevoTema)
        {
            TemaActual = nuevoTema;
        }

        public static Color FondoPrincipal => TemaActual == Tema.Claro ? ColoresApp.Claro_FondoPrincipal : ColoresApp.Oscuro_FondoPrincipal;
        public static Color FondoPanel => TemaActual == Tema.Claro ? ColoresApp.Claro_FondoPaneles : ColoresApp.Oscuro_FondoPaneles;
        public static Color FondoBoton => TemaActual == Tema.Claro ? ColoresApp.Claro_FondoBoton : ColoresApp.Oscuro_FondoBoton;
        public static Color Texto => TemaActual == Tema.Claro ? ColoresApp.Claro_Texto : ColoresApp.Oscuro_Texto;
        public static Color Borde => TemaActual == Tema.Claro ? ColoresApp.Claro_Borde : ColoresApp.Oscuro_Borde;
        public static Color BotonActivo => TemaActual == Tema.Claro ? ColoresApp.Claro_BotonActivo : ColoresApp.Oscuro_BotonActivo;
        public static Color BotonInactivo => TemaActual == Tema.Claro ? ColoresApp.Claro_BotonInactivo : ColoresApp.Oscuro_BotonInactivo;
    }

}
