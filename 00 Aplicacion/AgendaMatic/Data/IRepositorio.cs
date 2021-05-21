using Entidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMatic.Data
{
    interface IRepositorio
    {
        Response SetCita(Cita cita);

        Response GetCitas(DateTime? fecha);

        Response UpdateCita(Cita cita);

        Response RemoveCita(Cita cita);

        Response SetUsuario(Usuario usuario);

        Response GetUsuarios();

        Response UpdateUsuario(Usuario usuario);

        Response RemoveUsuario(Usuario usuario);

        Response Log(Log log);

        Response GetBloque(long idBloque);
    }
}
