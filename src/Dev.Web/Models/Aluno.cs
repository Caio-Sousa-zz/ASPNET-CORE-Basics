using System;

namespace Dev.Web.Models
{
    public class Aluno
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}