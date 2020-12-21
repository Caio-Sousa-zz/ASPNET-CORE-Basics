using Dev.Web.Data;
using Dev.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Dev.Web.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno
            {
                Nome = "Caio",
                DataNascimento = DateTime.Now,
                Email = "caio@gmail.com"
            };

            _contexto.Add(aluno);
            _contexto.SaveChanges();

            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(a => a.Email == "caio@gmail.com");
            var aluno4 = _contexto.Alunos.Where(a => a.Nome == "Caio");

            aluno3.Nome = "Cesar";

            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View("_Layout");
        }
    }
}