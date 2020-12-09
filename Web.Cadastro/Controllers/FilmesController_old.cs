using Microsoft.AspNetCore.Mvc;
using Web.Cadastro.Models;

namespace Web.Cadastro.Controllers
{
    public class FilmesController_old : Controller
    {
        [HttpPost]
        public IActionResult Adicionar(Filme filme)
        {
            if (ModelState.IsValid)
            {

            }

            return View();
        }

        [HttpGet]
        public IActionResult Adicionar()
        {
            return View();
        }
    }
}