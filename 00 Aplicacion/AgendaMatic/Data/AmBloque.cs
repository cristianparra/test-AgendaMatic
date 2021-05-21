using System;
using System.Collections.Generic;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AmBloque
    {
        public AmBloque()
        {
            AmCita = new HashSet<AmCitum>();
        }

        public long Id { get; set; }
        public long? Bloque { get; set; }
        public TimeSpan? Hora { get; set; }
        public bool? Estado { get; set; }
        public string Limite { get; set; }

        public virtual ICollection<AmCitum> AmCita { get; set; }
    }
}
