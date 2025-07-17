namespace Vidrieria.Modelos
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }
        public string? Nombre { get; set; }
        public string? nombreUsuario { get; set; }
        public string? Clave { get; set; }
        public int? Estado { get; set; }
        public int? Nivel { get; set; }

        public Usuario() { }

        public Usuario(int id, string nombre, string usuario, string clave, int? estado = null, int? nivel = null)
        {
            Id_Usuario = id;
            Nombre = nombre;
            nombreUsuario = usuario;
            Clave = clave;
            Estado = estado;
            Nivel = nivel;
        }

        public override string ToString()
        {
            return $"[{Id_Usuario}] {Nombre} ({nombreUsuario}) - Nivel: {Nivel}, Estado: {Estado}";
        }


    }
}
