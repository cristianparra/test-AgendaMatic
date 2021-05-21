using AgendaMatic.Dominio;
using Entidad;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace AgendaMatic.Data
{
    public class Repositorio:IRepositorio
    {
        private readonly AgendaMaticContext _context;

        public Repositorio(AgendaMaticContext context)
        {
            _context = context;
        }

        public Response SetCita(Cita cita)
        {
            Response response = new Response();
            string mensaje = string.Empty;

            try
            {
                AmCitum citaDb = new AmCitum()
                {
                    Id = 0,
                    IdUsuario = cita.IdUsuario,
                    IdBloque = cita.IdBloque,
                    Nombre = cita.Nombre,
                    Descripcion = cita.Descripcion,
                    Estado = true,
                    Fecha = DateTime.Now
                };

                _context.AmCita.Add(citaDb);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                if (ex.InnerException != null)
                    mensaje += ", detalle: " + ex.InnerException.Message;

                response.CodigoError = "01";
            }

            response.MensajeError = mensaje;
            return response;
        }

        public Response GetCitas(DateTime? fecha)
        {
            Response response = new Response();
            List<InformacionBloque> bloquesCitas = new List<InformacionBloque>();

            using (var contextdb = _context)
            {
                var bloques = contextdb.AmBloques.ToList().GroupBy(x => x.Bloque);

                foreach (var bloque in bloques)
                {
                    InformacionBloque informacionBloque = new InformacionBloque();
                    informacionBloque.IdBloque = Convert.ToInt64(bloque.ToList().First().Bloque);
                    informacionBloque.Bloque = bloque.ToList();
                    informacionBloque.EstadoDisponibilidad = true;

                    var cita = contextdb.AmCita.Where(x => x.Fecha.Value.Day == fecha.Value.Day &&
                                                           x.Fecha.Value.Month == fecha.Value.Month &&
                                                           x.Fecha.Value.Year == fecha.Value.Year &&
                                                           x.IdBloque == bloque.Key && x.Estado).ToList();
                    if (cita.Count() > 0)
                    {
                        var _cita = (AmCitum)cita.First();
                        informacionBloque.IdCita = _cita.Id;
                        informacionBloque.NombreCita = _cita.Nombre;
                        var propietarioCita = contextdb.AmUsuarios.Where(x => x.Id == _cita.IdUsuario).ToList().First();
                        informacionBloque.PropietarioCita = propietarioCita.Nombre + " " + propietarioCita.Apellido;
                        informacionBloque.EstadoDisponibilidad = false;
                    }

                    bloquesCitas.Add(informacionBloque);
                }
            }

            response.Objeto = bloquesCitas;

            return response;
        }

        public Response UpdateCita(Cita cita)
        {
            Response response = new Response();

            return response;
        }

        public Response RemoveCita(Cita cita)
        {
            Response response = new Response();
            string mensaje = string.Empty;

            try
            {
                AmCitum citaDb = new AmCitum();
                citaDb.Id = cita.Id;
                citaDb.Estado = false;

                _context.AmCita.Update(citaDb);
                _context.SaveChanges();

            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                if (ex.InnerException != null)
                    mensaje += ", detalle: " + ex.InnerException.Message;

                response.CodigoError = "01";
            }

            response.MensajeError = mensaje;
            return response;
        }

        public Response SetUsuario(Usuario usuario)
        {
            Response response = new Response();
            string mensaje = string.Empty;

            try
            {
                AmUsuario usuarioNuevo = new AmUsuario()
                {
                    Apellido = usuario.Apellido.Trim(),
                    Contrasena = usuario.Contrasena.Trim(),
                    Correo = usuario.Correo.Trim(),
                    Nombre = usuario.Nombre.Trim(),
                    Estado = true
                };

                _context.AmUsuarios.Add(usuarioNuevo);
                _context.SaveChanges();

                response.Objeto = usuarioNuevo;
            }
            catch (Exception ex)
            {
                mensaje = ex.Message;
                if (ex.InnerException != null)
                    mensaje += ", detalle: " + ex.InnerException.Message;

                response.CodigoError = "01";
            }

            response.MensajeError = mensaje;
            return response;
        }

        public Response GetUsuarios()
        {
            Response response = new Response();

            response.Objeto = _context.AmUsuarios;

            return response;
        }

        public Response UpdateUsuario(Usuario usuario)
        {
            Response response = new Response();

            return response;
        }

        public Response RemoveUsuario(Usuario usuario)
        {
            Response response = new Response();

            return response;
        }

        public Response Log(Log log)
        {
            Response response = new Response();

            return response;
        }

        public Response GetBloque(long idBloque)
        {
            Response response = new Response();

            response.Objeto = _context.AmBloques.ToList().Where(x => x.Bloque.Value == idBloque).ToList();

            return response;
        }
    }
}
