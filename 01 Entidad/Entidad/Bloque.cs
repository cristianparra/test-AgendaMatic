using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Bloque
    {
        public long Id { get; set; }
        public long? NombreBloque { get; set; }
        public TimeSpan? Hora { get; set; }
        public bool? Estado { get; set; }
    }
}
