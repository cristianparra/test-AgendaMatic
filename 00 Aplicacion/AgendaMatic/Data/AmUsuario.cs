using System;
using System.Collections.Generic;

#nullable disable

namespace AgendaMatic.Data
{
    public partial class AmUsuario
    {
        public AmUsuario()
        {
            AmCita = new HashSet<AmCitum>();
            AmLogs = new HashSet<AmLog>();
        }

        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public bool? Estado { get; set; }

        public virtual ICollection<AmCitum> AmCita { get; set; }
        public virtual ICollection<AmLog> AmLogs { get; set; }
    }
}
