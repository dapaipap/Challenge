using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class RondaJuego
    {
        public int IdRondaJuego { get; set; }
        public int? IdJuego { get; set; }
        public int IdPregunta { get; set; }
        public int? IdRespuesta { get; set; }
        public int IdNivel { get; set; }
        public int? PremioObtenido { get; set; }
        public bool? RespuestaCorrecta { get; set; }
        public DateTime FechaCreacion { get; set; }

        public virtual Juego IdJuegoNavigation { get; set; }
        public virtual Pregunta IdPreguntaNavigation { get; set; }
    }
}
