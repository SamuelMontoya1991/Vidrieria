using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vidrieria.Clases
{
    

    public static class ColoresApp
    {
        // Tema claro
        public static Color Claro_FondoPrincipal => Color.Black;
        public static Color Claro_FondoPaneles => Color.FromArgb(255, 255, 192);
        public static Color Claro_FondoBoton => Color.FromArgb(255, 255, 192);
        public static Color Claro_BotonActivo => Color.FromArgb(255, 255, 192);
        public static Color Claro_BotonInactivo => Color.FromArgb(192, 255, 192);
        public static Color Claro_Texto => Color.Black;
        public static Color Claro_Borde => Color.LightGray;

        // Tema oscuro
        public static Color Oscuro_FondoPrincipal => Color.Black;
        public static Color Oscuro_FondoPaneles => Color.DarkCyan;
        public static Color Oscuro_FondoBoton => Color.DarkCyan;
        public static Color Oscuro_BotonActivo => Color.DarkCyan;
        public static Color Oscuro_BotonInactivo => Color.LightCyan;
        public static Color Oscuro_Texto => Color.White;
        public static Color Oscuro_Borde => Color.FromArgb(60, 60, 60);


    }



    public static class EstilosControles
    {
        public static void AplicarEstiloFormulario(Form form)
        {
            form.BackColor = TemaDeApp.FondoPrincipal;
            form.ForeColor = TemaDeApp.Texto;
            form.Font = new Font("Segoe UI", 9F);
            AplicarEstiloRecursivo(form);
        }

        public static void AplicarEstiloBoton(Button boton)
        {
            boton.BackColor = TemaDeApp.FondoBoton;
            boton.ForeColor = TemaDeApp.Texto;
            boton.FlatStyle = FlatStyle.Standard;
            boton.FlatAppearance.BorderSize = 0;
            boton.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            boton.Cursor = Cursors.Hand;
        }

        public static void AplicarEstiloPanel(Panel panel)
        {
            panel.BackColor = TemaDeApp.FondoPanel;
            panel.BorderStyle = BorderStyle.FixedSingle;
        }
        public static void AplicarEstiloMdi(MdiClient mdi)
        {
            mdi.BackColor = TemaDeApp.FondoPrincipal;
            
        }
        public static void AplicarEstiloDataGrid(DataGridView dgv)
        {
            dgv.BackgroundColor = TemaDeApp.FondoPanel;
            dgv.GridColor = TemaDeApp.Borde;
            dgv.BorderStyle = BorderStyle.Fixed3D;
           

            dgv.EnableHeadersVisualStyles = false;

            dgv.ColumnHeadersDefaultCellStyle.BackColor = TemaDeApp.FondoBoton;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TemaDeApp.Texto;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);

            dgv.DefaultCellStyle.BackColor = TemaDeApp.FondoPanel;
            dgv.DefaultCellStyle.ForeColor = TemaDeApp.Texto;
            dgv.DefaultCellStyle.SelectionBackColor = TemaDeApp.TemaActual == Tema.Claro ? ColoresApp.Claro_BotonInactivo : ColoresApp.Claro_BotonActivo;
            dgv.DefaultCellStyle.SelectionForeColor = TemaDeApp.Texto;

            dgv.RowsDefaultCellStyle.BackColor = TemaDeApp.FondoPanel;
            dgv.RowsDefaultCellStyle.ForeColor = TemaDeApp.Texto;

            dgv.RowHeadersVisible = false;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToResizeRows = false;

            dgv.Refresh();
        }
        public static void AplicarEstiloTextBox(TextBox txt)
        {
            txt.BackColor = TemaDeApp.FondoPanel;
            txt.ForeColor = TemaDeApp.Texto;
            txt.BorderStyle = BorderStyle.Fixed3D;
            txt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }
        public static void AplicarEstiloTextBox(MaskedTextBox txt)
        {
            txt.BackColor = TemaDeApp.FondoPanel;
            txt.ForeColor = TemaDeApp.Texto;
            txt.BorderStyle = BorderStyle.Fixed3D;
            txt.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        }

        public static void AplicarEstiloRecursivo(Control control)
        {
            foreach (Control c in control.Controls)
            {
                if (c is Button b)
                    AplicarEstiloBoton(b);
                else if (c is Panel p)
                    AplicarEstiloPanel(p);
                else if (c is DataGridView dgv)
                    AplicarEstiloDataGrid(dgv);
                else if (c is MdiClient mp)
                    AplicarEstiloMdi(mp);
                else if (c is TextBox txt)
                    AplicarEstiloTextBox(txt);
                else if (c is Label lbl)
                {
                    lbl.BackColor = Color.Transparent; 
                    lbl.ForeColor = TemaDeApp.Texto;
                }
                else if (c is ComboBox cb)
                {
                    cb.BackColor = TemaDeApp.FondoPanel;
                    cb.ForeColor = TemaDeApp.Texto;
                    cb.FlatStyle = FlatStyle.Standard;
                }
                else if (c is CheckBox chk)
                {
                    chk.BackColor = Color.Transparent; 
                    chk.ForeColor = TemaDeApp.Texto;
                }
                else if (c is MaskedTextBox mtb)
                     AplicarEstiloTextBox(mtb);
                else
                    c.BackColor = TemaDeApp.FondoPanel;
                    c.ForeColor = TemaDeApp.Texto;

                if (c.HasChildren)
                    AplicarEstiloRecursivo(c);
            }
        }
    }


}
