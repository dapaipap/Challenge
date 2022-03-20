using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class Respuesta
    {
        public int IdRespuesta { get; set; }
        public string Descipcion { get; set; }
        public bool EsCorrecta { get; set; }
    }
}
