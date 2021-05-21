using AgendaMatic.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Entidad;
using AgendaMatic.Data;
using AgendaMatic.Dominio;

namespace AgendaMatic.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositorio _repositorio;

        public HomeController(ILogger<HomeController> logger, AgendaMaticContext context)
        {
            _logger = logger;
            _repositorio = new Repositorio(context);
        }

        public IActionResult Index()
        {
            InfoUsuario infoUsuario = (InfoUsuario)HttpContext.Session.GetComplexData<InfoUsuario>("InfoUsuario");

            if (infoUsuario != null)
            {
                HomeViewModel viewModel = new HomeViewModel();
                viewModel.infoUsuario = infoUsuario;
                viewModel.Bloques = (List<InformacionBloque>)_repositorio.GetCitas(DateTime.Now).Objeto;

                return View(viewModel);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Registro()
        {
            return View();
        }

        [HttpGet]
        public IActionResult AgendaCita(int idBloque)
        {
            var response = _repositorio.GetBloque(Convert.ToInt64(idBloque));
            HomeViewModel viewModel = new HomeViewModel();
            viewModel.IdBloque = Convert.ToInt64(idBloque);
            viewModel.Bloque = new List<AmBloque>();
            viewModel.Bloque = (List<AmBloque>)response.Objeto;
            viewModel.TextoHorarioBloque = String.Format("Bloque de {0} a {1}",viewModel.Bloque.Where(x => x.Limite == "INICIO").ToList().First().Hora.Value.ToString(@"hh\:mm"),
                                                                               viewModel.Bloque.Where(x => x.Limite == "FIN").ToList().First().Hora.Value.ToString(@"hh\:mm"));

            return View(viewModel);
        }
    }
}
