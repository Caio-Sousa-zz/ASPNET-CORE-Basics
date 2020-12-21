using Microsoft.Extensions.Configuration;

namespace Dev.Web.Data
{
    public class MeuDbContextFactory 
    {
        private IConfiguration Configuration { get; }

        public MeuDbContextFactory(IConfiguration configuration)
        {
            Configuration = configuration;
        }
    }
}