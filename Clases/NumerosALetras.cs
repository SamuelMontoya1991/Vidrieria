namespace Vidrieria.Clases
{
    using System.Text.RegularExpressions;


    public class NumerosEnLetras
    {
        private readonly string[] UNIDADES = { "", "UN ", "DOS ", "TRES ", "CUATRO ", "CINCO ", "SEIS ", "SIETE ", "OCHO ", "NUEVE " };
        private readonly string[] DECENAS = {
        "DIEZ ", "ONCE ", "DOCE ", "TRECE ", "CATORCE ", "QUINCE ",
        "DIECISEIS ", "DIECISIETE ", "DIECIOCHO ", "DIECINUEVE",
        "VEINTE ", "TREINTA ", "CUARENTA ", "CINCUENTA ",
        "SESENTA ", "SETENTA ", "OCHENTA ", "NOVENTA "
    };
        private readonly string[] CENTENAS = {
        "", "CIENTO ", "DOSCIENTOS ", "TRECIENTOS ", "CUATROCIENTOS ",
        "QUINIENTOS ", "SEISCIENTOS ", "SETECIENTOS ", "OCHOCIENTOS ", "NOVECIENTOS "
    };
        public NumerosEnLetras() { }

        public string Convertir(string numero, bool mayusculas)
        {
            string literal = "";
            string parteDecimal;

            numero = numero.Replace('.', ',');

            if (!numero.Contains(","))
            {
                numero += ",00";
            }

            if (Regex.IsMatch(numero, @"^\d{1,9},\d{1,2}$"))
            {
                string[] Num = numero.Split(',');
                parteDecimal = "LEMPIRAS CON " + Num[1].PadRight(2, '0') + "/100 CENTAVOS.";

                int parteEntera = int.Parse(Num[0]);

                if (parteEntera == 0)
                {
                    literal = "CERO ";
                }
                else if (parteEntera > 999999)
                {
                    literal = GetMillones(Num[0]);
                }
                else if (parteEntera > 999)
                {
                    literal = GetMiles(Num[0]);
                }
                else if (parteEntera > 99)
                {
                    literal = GetCentenas(Num[0]);
                }
                else if (parteEntera > 9)
                {
                    literal = GetDecenas(Num[0]);
                }
                else
                {
                    literal = GetUnidades(Num[0]);
                }

                return mayusculas ? (literal + parteDecimal).ToUpper() : (literal + parteDecimal);
            }
            else
            {
                return null;
            }
        }

        private string GetUnidades(string numero)
        {
            string num = numero.Substring(numero.Length - 1);
            return UNIDADES[int.Parse(num)];
        }

        private string GetDecenas(string num)
        {
            int n = int.Parse(num);
            if (n < 10)
            {
                return GetUnidades(num);
            }
            else if (n > 19)
            {
                string u = GetUnidades(num);
                string decena = DECENAS[int.Parse(num.Substring(0, 1)) + 8];
                return string.IsNullOrEmpty(u.Trim()) ? decena : decena + "y " + u;
            }
            else
            {
                return DECENAS[n - 10];
            }
        }

        private string GetCentenas(string num)
        {
            int n = int.Parse(num);
            if (n > 99)
            {
                if (n == 100)
                {
                    return "CIEN ";
                }
                else
                {
                    return CENTENAS[int.Parse(num.Substring(0, 1))] + GetDecenas(num.Substring(1));
                }
            }
            else
            {
                return GetDecenas(n.ToString());
            }
        }

        private string GetMiles(string numero)
        {
            string c = numero.Substring(numero.Length - 3);
            string m = numero.Substring(0, numero.Length - 3);

            if (int.Parse(m) > 0)
            {
                return GetCentenas(m) + "MIL " + GetCentenas(c);
            }
            else
            {
                return GetCentenas(c);
            }
        }

        private string GetMillones(string numero)
        {
            string miles = numero.Substring(numero.Length - 6);
            string millon = numero.Substring(0, numero.Length - 6);

            string n = millon.Length > 1 ? GetCentenas(millon) + "MILLONES " : GetUnidades(millon) + "MILLON ";
            return n + GetMiles(miles);
        }
    }

}
