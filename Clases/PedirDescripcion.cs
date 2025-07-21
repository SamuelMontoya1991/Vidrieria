using System.Windows.Forms;


namespace Vidrieria.Clases
{
    public class PedirDescripcion
    {
        public static string PedirDescripcionGeneral(string titulo, string mensaje)
        {
            Form prompt = new Form()
            {
                Width = 400,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = titulo,
                StartPosition = FormStartPosition.CenterScreen
            };

            Label texto = new Label() { Left = 20, Top = 20, Text = mensaje, Width = 340 };
            TextBox input = new TextBox() { Left = 20, Top = 50, Width = 340 };
            Button aceptar = new Button() { Text = "Aceptar", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };

            prompt.Controls.Add(texto);
            prompt.Controls.Add(input);
            prompt.Controls.Add(aceptar);
            prompt.AcceptButton = aceptar;

            return prompt.ShowDialog() == DialogResult.OK ? input.Text : string.Empty;
        }

    }
}
