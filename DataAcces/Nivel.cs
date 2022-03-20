using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class Nivel
    {
        public Nivel()
        {
            Juegos = new HashSet<Juego>();
            Pregunta = new HashSet<Pregunta>();
        }

        public int IdNivel { get; set; }
        public string Descipcion { get; set; }
        public int? Premio { get; set; }

        public virtual ICollection<Juego> Juegos { get; set; }
        public virtual ICollection<Pregunta> Pregunta { get; set; }
    }
}
