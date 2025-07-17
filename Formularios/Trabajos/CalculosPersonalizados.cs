using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vidrieria.Clases;
using Vidrieria.Interfaces;
using Vidrieria.Modelos;

namespace Vidrieria.Formularios.Trabajos
{
    public partial class CalculosPersonalizados : Form, IFormularioConUsuario, IFormularioConTema
    {
        private ConexionDB BD = new ConexionDB();
        Tema temaActual;
        private Usuario usuario;

        public CalculosPersonalizados()
        {
            InitializeComponent();
        }

        public void AplicarTema(Tema tema)
        {
            this.temaActual = tema;
            TemaDeApp.CambiarTema(tema);
            EstilosControles.AplicarEstiloFormulario(this);
        }

        public void InicializarUsuario(Usuario usuario)
        {
            this.usuario = usuario;
        }

        private void tblTrabajos_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                if (tblTrabajos.SelectedRows.Count > 0)
                {
                    foreach (DataGridViewRow row in tblTrabajos.SelectedRows)
                    {
                        if (!row.IsNewRow)
                        {
                            tblTrabajos.Rows.Remove(row);
                        }
                    }
                }
            }
        }
    }
}
