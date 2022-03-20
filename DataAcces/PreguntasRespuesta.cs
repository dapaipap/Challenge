using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class PreguntasRespuesta
    {
        public int IdPregunta { get; set; }
        public int IdRespuesta { get; set; }

        public virtual Pregunta IdPreguntaNavigation { get; set; }
        public virtual Respuesta IdRespuestaNavigation { get; set; }
    }
}
