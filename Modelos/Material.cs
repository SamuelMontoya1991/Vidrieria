namespace Vidrieria.Modelos
{
    public class ModeloMaterial
    {
        public int id { get; set; }
        public string? descripcion { get; set; }
        public double natural { get; set; }
        public double bronce { get; set; }
        public double madera { get; set; }
        public int arco,
            livianacorrediza,
            semipesada,
            fijapesada,
            fijaliviana,
            guillotina,
            pvpesada,
            pvpesadadoble,
            pabatible,
            pbaniousa,
            pbanio,
            vitrina, extra, tipo;

        public ModeloMaterial() { }

        public ModeloMaterial(int id, string? descripcion, double natural, double bronce, double madera, int arco, int livianacorrediza, int semipesada, int fijapesada, int fijaliviana, int guillotina, int pvpesada, int pvpesadadoble, int pabatible, int pbaniousa, int pbanio, int vitrina, int extra, int tipo)
        {
            this.id = id;
            this.descripcion = descripcion;
            this.natural = natural;
            this.bronce = bronce;
            this.madera = madera;
            this.arco = arco;
            this.livianacorrediza = livianacorrediza;
            this.semipesada = semipesada;
            this.fijapesada = fijapesada;
            this.fijaliviana = fijaliviana;
            this.guillotina = guillotina;
            this.pvpesada = pvpesada;
            this.pvpesadadoble = pvpesadadoble;
            this.pabatible = pabatible;
            this.pbaniousa = pbaniousa;
            this.pbanio = pbanio;
            this.vitrina = vitrina;
            this.extra = extra;
            this.tipo = tipo;
        }

        override
        public string ToString()
        {
            return $" id={id} " +
                $"- descripcion= {descripcion} " +
                $"-  natural= {natural} " +
                $"- bronce= {bronce} " +
                $"- madera= {madera} " +
                $"- arco= {arco} " +
                $"- livianacorrediza= {livianacorrediza} " +
                $"- semipesada= {semipesada} " +
                $"- fijapesada= {fijapesada} " +
                $"- fijaliviana= {fijaliviana} " +
                $"- guillotina= {guillotina} " +
                $"- pvpesada= {pvpesada}" +
                $"- pesadadoble= {pvpesadadoble} " +
                $"- abatible= {pabatible} " +
                $"- baniousa= {pbaniousa} " +
                $"- banio= {pbanio} " +
                $"- vitrina= {vitrina} " +
                $"- extra= {extra} " +
                $"- tipo= {tipo}";
        }




    }
}
