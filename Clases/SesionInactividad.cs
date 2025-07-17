using System.Runtime.InteropServices;
using System.Windows.Forms;
using Vidrieria.Formularios.Login;

namespace Vidrieria.Clases
{


    public static class SesionInactividad
    {
        [StructLayout(LayoutKind.Sequential)]
        struct LASTINPUTINFO
        {
            public uint cbSize;
            public uint dwTime;
        }

        [DllImport("user32.dll")]
        static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        [DllImport("kernel32.dll")]
        static extern uint GetTickCount();

        private static System.Windows.Forms.Timer timer = null;
        private static int segundosLimite = 600; // 10 minutos

        public static void IniciarControl(Form formularioPrincipal)
        {
            if (timer == null)
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = 10000; // cada 10 segundos
                timer.Tick += (s, e) =>
                {
                    int inactivos = ObtenerSegundosInactivos();
                    if (inactivos >= segundosLimite)
                    {
                        timer.Stop();
                        MessageBox.Show("Sesión cerrada por inactividad.", "Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        formularioPrincipal.Hide();
                        new LoginForm().Show();
                    }
                };
                timer.Start();
            }
        }

        private static int ObtenerSegundosInactivos()
        {
            LASTINPUTINFO info = new LASTINPUTINFO();
            info.cbSize = (uint)Marshal.SizeOf(info);
            if (!GetLastInputInfo(ref info)) return 0;
            return (int)((GetTickCount() - info.dwTime) / 1000);
        }

        public static void Reiniciar()
        {
            // No es necesario con GetLastInputInfo, pero puedes usarlo si decides hacerlo manual
        }
    }

}
