using AgendaMatic.Data;
using AgendaMatic.Dominio;
using Entidad;
using System.Collections.Generic;

namespace AgendaMatic.Models
{
    public class HomeViewModel
    {
        public InfoUsuario infoUsuario { get; set; }
        public List<InformacionBloque> Bloques { get; set; }

        public long IdBloque { get; set; }
        public List<AmBloque> Bloque { get; set; }
        public string TextoHorarioBloque { get; set; }
    }
}
