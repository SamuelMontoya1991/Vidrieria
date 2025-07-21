using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Vidrieria.Clases
{
    public partial class ToastNotificationForm : Form
    {
        private Action _onVerClick;
        private Timer fadeInTimer;
        private Timer fadeOutTimer;
        private int visibleTime = 5000; // milisegundos antes de empezar fade-out
        private int fadeStep = 20;

        public ToastNotificationForm(string mensaje)
        {
            

            this.FormBorderStyle = FormBorderStyle.None;
            this.StartPosition = FormStartPosition.Manual;
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Opacity = 0;
            this.BackColor = Color.White;
            this.Size = new Size(350, 80);
            this.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 15, 15));

            var contenedor = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(10)
            };
            this.Controls.Add(contenedor);

            var icon = new PictureBox
            {
                Image = SystemIcons.Warning.ToBitmap(),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Size = new Size(32, 32),
                Location = new Point(10, 15)
            };
            contenedor.Controls.Add(icon);

            var btnCerrar = new Button
            {
                Text = "✖",
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.Gray,
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Size = new Size(30, 30),
                Location = new Point(this.Width - 40, 5)
            };
            btnCerrar.FlatAppearance.BorderSize = 0;
            btnCerrar.Click += (s, e) => this.Close();
            this.Controls.Add(btnCerrar);

            var lblMensaje = new Label
            {
                Text = mensaje,
                AutoSize = false,
                Size = new Size(270, 60),
                Location = new Point(50, 10),
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Black
            };
            contenedor.Controls.Add(lblMensaje);

            // Animaciones
            fadeInTimer = new Timer();
            fadeInTimer.Interval = 180;
            fadeInTimer.Tick += (s, e) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.1;
                else
                {
                    fadeInTimer.Stop();
                    VibrarVentana();

                    var holdTimer = new Timer { Interval = visibleTime };
                    holdTimer.Tick += (s2, e2) =>
                    {
                        holdTimer.Stop();
                        fadeOutTimer.Start();
                    };
                    holdTimer.Start();
                }
            };

            fadeOutTimer = new Timer();
            fadeOutTimer.Interval = 150;
            fadeOutTimer.Tick += (s, e) =>
            {
                if (this.Opacity > 0)
                    this.Opacity -= 0.1;
                else
                {
                    fadeOutTimer.Stop();
                    this.Close();
                }
            };

            fadeInTimer.Start();
        }

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        private async void VibrarVentana()
        {
            var original = this.Location;
            int amplitud = 5;

            for (int i = 0; i < 10; i++)
            {
                this.Location = new Point(original.X + (i % 2 == 0 ? -amplitud : amplitud), original.Y);
                await Task.Delay(30);
            }

            this.Location = original;
        }
    }

}
