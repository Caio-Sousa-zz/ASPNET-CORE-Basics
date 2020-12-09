using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Web.Cadastro.Data;

namespace Web.Cadastro
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();            

            services.AddDbContext<WebCadastroContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("WebCadastroContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/routing?view=aspnetcore-5.0
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                 name: "modulos",
                 pattern: "Gestao/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                  name: "categoria",
                  pattern: "{controller=Home}/{action=Index}/{id}/{categoria?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}