using System;
using System.Collections.Generic;

#nullable disable

namespace DataAcces
{
    public partial class Usuario
    {
        public Usuario()
        {
            Juegos = new HashSet<Juego>();
        }

        public int IdUsuario { get; set; }
        public string Nick { get; set; }
        public DateTime? FechaRegistro { get; set; }

        public virtual ICollection<Juego> Juegos { get; set; }
    }
}
