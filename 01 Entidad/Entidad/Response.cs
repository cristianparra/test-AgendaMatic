using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidad
{
    public class Response
    {
        public Response()
        {
            CodigoError = "00";
            EstadoError = false;
            MensajeError = "OK";
            MensajeHumano = "Todo Ok";
        }

        public string CodigoError
        {
            get; set;
        }

        public object Objeto
        {
            get; set;
        }

        public bool EstadoError
        {
            get; set;
        }

        public string MensajeError
        {
            get; set;
        }

        public string MensajeHumano
        {
            get; set;
        }
    }
}
