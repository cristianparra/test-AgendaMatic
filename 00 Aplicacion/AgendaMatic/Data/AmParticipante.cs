using System;
using System.Collections.Generic;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AmParticipante
    {
        public long Id { get; set; }
        public long? IdAmCita { get; set; }
        public long? IdAmUsuario { get; set; }

        public virtual AmCitum IdAmCitaNavigation { get; set; }
        public virtual AmUsuario IdAmUsuarioNavigation { get; set; }
    }
}
