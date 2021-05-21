using System;
using System.Collections.Generic;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AmLog
    {
        public long Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
        public long? IdUsuario { get; set; }

        public virtual AmUsuario IdUsuarioNavigation { get; set; }
    }
}
