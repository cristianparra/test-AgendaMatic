using System;
using System.Collections.Generic;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AmCitum
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public long? IdBloque { get; set; }
        public long? IdUsuario { get; set; }
        public DateTime? Fecha { get; set; }
        public bool Estado { get; set; }

        public virtual AmBloque IdBloqueNavigation { get; set; }
        public virtual AmUsuario IdUsuarioNavigation { get; set; }
    }
}
