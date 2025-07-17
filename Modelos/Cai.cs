namespace Vidrieria.Modelos
{
    public class ModeloCai
    {
        public string? id_cai { get; set; }
        public string? cai { get; set; }
        public string? rango_inicial { get; set; }
        public string? rango_final { get; set; }
        public string? fecha_limite { get; set; }
        public int? estado { get; set; }

        public ModeloCai() { }
        public ModeloCai(string? id_cai, string? cai, string? rango_inicial, string? rango_final, string? fecha_limite, int? estado)
        {
            this.id_cai = id_cai;
            this.cai = cai;
            this.rango_inicial = rango_inicial;
            this.rango_final = rango_final;
            this.fecha_limite = fecha_limite;
            this.estado = estado;
        }

        public ModeloCai(string? cai, string? rango_inicial, string? rango_final, string? fecha_limite, int? estado)
        {
            this.cai = cai;
            this.rango_inicial = rango_inicial;
            this.rango_final = rango_final;
            this.fecha_limite = fecha_limite;
            this.estado = estado;
        }
    }
}
