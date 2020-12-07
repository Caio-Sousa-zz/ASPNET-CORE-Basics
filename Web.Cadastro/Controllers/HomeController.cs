using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using Web.Cadastro.Models;

namespace Web.Cadastro.Controllers
{
    [Route("")]
    [Route("gestao-clientes")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Route("")]
        [Route("pagina-inicial")]
        [Route("pagina-inicial/{id:int}/{categoria:guid?}")]
        public IActionResult Index(int id, Guid categoria)
        {
            return View();
        }

        [Route("privacidade")]
        [Route("politica-de-privacidade")]
        public IActionResult Privacy()
        {
            // JSON
            //return Json("{'nome':'Caio'}");

            // Arquivo
            //var fileBytes = System.IO.File.ReadAllBytes(@"D:\Main\2021\Projetos\MVC-Core\Web.Cadastro\wwwroot\favicon.ico");
            //var fileName = "icone.ico";
            //return File(fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("erro-encontrado")]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}