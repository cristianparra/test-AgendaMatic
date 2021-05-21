using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Log
    {
        public long Id { get; set; }
        public string Mensaje { get; set; }
        public DateTime? Fecha { get; set; }
        public long? IdUsuario { get; set; }
    }
}
