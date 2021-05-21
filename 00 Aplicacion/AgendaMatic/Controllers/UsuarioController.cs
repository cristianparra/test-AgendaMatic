using AgendaMatic.Data;
using AgendaMatic.Models;
using Entidad;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgendaMatic.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;

        public UsuarioController(ILogger<HomeController> logger, AgendaMaticContext context)
        {
            _logger = logger;
            _repositorio = new Repositorio(context);
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login([FromBody]UsuarioLogin usuario)
        {
            string validacion = "NOOK";
            var response = _repositorio.GetUsuarios();

            if (response.CodigoError == "00")
            {
                var _usuarios = (IEnumerable<AmUsuario>)response.Objeto;

                if (_usuarios != null)
                {
                    AmUsuario _usuario = new AmUsuario();
                    try
                    {
                        var usuario_ = _usuarios.Where(x =>
                        x.Correo.ToLower() == usuario.usuario.Trim().ToLower()
                        && x.Contrasena.ToLower().Trim() == usuario.contrasena.Trim().ToLower()).First();
                        _usuario = usuario_;
                    }
                    catch (Exception)
                    {
                        return Json(new { status = false, messege = "Usuario no existe" });
                    }                    

                    if (_usuario != null)
                    {
                        validacion = "OK";
                        HttpContext.Session.SetComplexData("InfoUsuario", new InfoUsuario() { estado = _usuario.Estado, usuario = _usuario.Correo , idUsuario = _usuario.Id});
                        return Json(new { status = true, messege = validacion });
                    }
                    else
                    {
                        return Json(new { status = false, messege = "Cedenciales Incorrectas" });
                    }
                }
                else 
                {
                    return Json(new { status = false, messege = "Usuario no existe" });
                }
            }
            else
            {
                return Json(new { status = false, messege = response.MensajeError });
            }
        }

        public IActionResult Logout() 
        {
            HttpContext.Session.SetComplexData("InfoUsuario", null);

            return RedirectToAction("Login", "Home");
        }

        [HttpPost]
        public IActionResult RegistroUsuario([FromBody] Usuario usuario)
        {
            string validacion = "NOOK";
            var response = _repositorio.GetUsuarios();

            if (response.CodigoError == "00")
            {
                var _usuarios = (IEnumerable<AmUsuario>)response.Objeto;

                if (_usuarios != null)
                {
                    AmUsuario _usuario = new AmUsuario();
                    try
                    {
                        var usuario_ = _usuarios.ToList().Where(x => x.Correo.ToLower() == usuario.Correo.Trim().ToLower()).ToList();

                        if(usuario_.Count > 1)
                            _usuario = usuario_.First();
                    }
                    catch (Exception)
                    {
                        return Json(new { status = false, messege = "Usuario existente" });
                    }

                    if (_usuario.Id != 0)
                    {
                        validacion = "Usuario Existente";
                        return Json(new { status = true, messege = validacion });
                    }
                    else
                    {
                        var _response = _repositorio.SetUsuario(usuario);
                        string strmsg = "Problemas al ingresado datos";
                        bool status = false;

                        if (_response.CodigoError == "00")
                        {
                            strmsg = "OK";
                            status = true;
                            _usuario = (AmUsuario)_response.Objeto;
                            HttpContext.Session.SetComplexData("InfoUsuario", new InfoUsuario() { estado = _usuario.Estado, usuario = _usuario.Correo , idUsuario = _usuario.Id});
                        }

                        return Json(new { status = status , messege = strmsg });
                    }
                }
                else
                {
                    return Json(new { status = false, messege = "Inconsistencia de datos" });
                }
            }
            else
            {
                return Json(new { status = false, messege = response.MensajeError });
            }
        }

        [HttpPost]
        public IActionResult AnularCita([FromBody]Cita cita)
        {
            var response = _repositorio.RemoveCita(cita);

            if (response.CodigoError == "00")
            {
                return Json(new { status = true, messege = "OK" });
            }
            else 
            {
                return Json(new { status = false, messege = response.MensajeError });
            }
        }

        [HttpPost]
        public IActionResult AgendarCita([FromBody]Cita cita)
        {
            InfoUsuario infoUsuario = (InfoUsuario)HttpContext.Session.GetComplexData<InfoUsuario>("InfoUsuario");

            cita.IdUsuario = infoUsuario.idUsuario;

            var response = _repositorio.SetCita(cita);

            if (response.CodigoError == "00")
            {
                return Json(new { status = true, messege = "OK" });
            }
            else
            {
                return Json(new { status = false, messege = response.MensajeError });
            }
        }

        
    }
}
