using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class Pregunta
    {
        public Pregunta()
        {
            RondaJuegos = new HashSet<RondaJuego>();
        }

        public int IdPregunta { get; set; }
        public string Descripcion { get; set; }
        public int IdNivel { get; set; }

        public virtual Nivel IdNivelNavigation { get; set; }
        public virtual ICollection<RondaJuego> RondaJuegos { get; set; }
    }
}
