using Dev.Web.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Dev.Web.Data
{
    public class MeuDbContext : DbContext
    {
        public MeuDbContext(DbContextOptions<MeuDbContext> options): base(options)
        {
        }

        public DbSet<Aluno> Alunos { get; set; }
    }
}