namespace Vidrieria.Modelos
{
    public class ModeloEmpresa
    {
        public string? id_empresa { get => id_empresa; set => id_empresa = value; }
        public string? nombre { get => nombre; set => nombre = value; }
        public string? direccion { get => direccion; set => direccion = value; }
        public string? telefono { get => telefono; set => telefono = value; }
        public string? correo { get => correo; set => correo = value; }
        public string? RTN { get => RTN; set => RTN = value; }
        public string? encabezado { get => encabezado; set => encabezado = value; }
        public string? encabezado2 { get => encabezado2; set => encabezado2 = value; }
        public string? eslogan { get => eslogan; set => eslogan = value; }
        public string? nota { get => nota; set => nota = value; }

        public ModeloEmpresa() { }

        public ModeloEmpresa(string id_empresa, string nombre, string direccion, string telefono, string correo, string RTN, string encabezado, string encabezado2, string eslogan, string nota)
        {
            this.id_empresa = id_empresa;
            this.nombre = nombre;
            this.direccion = direccion;
            this.telefono = telefono;
            this.correo = correo;
            this.RTN = RTN;
            this.encabezado = encabezado;
            this.encabezado2 = encabezado2;
            this.eslogan = eslogan;
            this.nota = nota;
        }
    }
}
