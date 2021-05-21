using AgendaMatic.Data;
using System.Collections.Generic;
using System.Linq;

namespace AgendaMatic.Dominio
{
    public class InformacionBloque
    {
        public InformacionBloque()
        {
            Bloque = new List<AmBloque>();
            ListaParticipantes = new List<AmParticipante>();
        }

        public long IdBloque { get; set; }
        public long IdCita { get; set; }
        public List<AmBloque> Bloque { get; set; }
        public string NombreCita { get; set; }
        public List<AmParticipante> ListaParticipantes { get; set; }
        public string PropietarioCita { get; set; }
        public bool EstadoDisponibilidad { get; set; }
    }
}
