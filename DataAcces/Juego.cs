using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class Juego
    {
        public Juego()
        {
            RondaJuegos = new HashSet<RondaJuego>();
        }

        public int IdJuego { get; set; }
        public int IdUsuario { get; set; }
        public int IdNivelAlcanzado { get; set; }
        public int? PremioAcumulado { get; set; }
        public int? IdTipoFinalizacion { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaFinalizacion { get; set; }

        public virtual Nivel IdNivelAlcanzadoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<RondaJuego> RondaJuegos { get; set; }
    }
}
