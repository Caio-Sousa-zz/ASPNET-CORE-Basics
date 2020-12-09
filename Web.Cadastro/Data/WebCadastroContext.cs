using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Web.Cadastro.Models;

namespace Web.Cadastro.Data
{
    public class WebCadastroContext : DbContext
    {
        public WebCadastroContext (DbContextOptions<WebCadastroContext> options)
            : base(options)
        {
        }

        public DbSet<Web.Cadastro.Models.Filme> Filme { get; set; }
    }
}
