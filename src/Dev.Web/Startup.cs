using Dev.Web.Data;
using Dev.Web.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;

namespace Dev.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            // Configurar pasta Modulos em vez de padr�o Area
            services.Configure<RazorViewEngineOptions>(op =>
            {
                op.AreaViewLocationFormats.Clear();
                op.AreaViewLocationFormats.Add(item: "/Modulos/{2}/Views/{1}/{0}.cshtml");
                op.AreaViewLocationFormats.Add(item: "/Modulos/{2}/Views/Shared/{0}.cshtml");
                op.AreaViewLocationFormats.Add(item: "/Views/Shared/{0}.cshtml");
            });
                                 
            services.AddDbContext<MeuDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("MeuDbContext")));

            services.AddControllersWithViews();

            // Adicione de forma transiente uma config de inje��o de dependencia.
            // Crie essa instancia para min caso eu precisar dela.
            // Baseado em contrato
            services.AddTransient<IPedidoRepository, PedidoRepository>();

            //Obt�m uma nova inst�ncia do objeto a cada solicita��o
            services.AddTransient<IOperacaoTransient, Operacao>();
            //Reutiliza a mesma inst�ncia do objeto durante todo o request (web).
            services.AddScoped<IOperacaoScoped, Operacao>();
            //Utiliza a mesma instancia para toda aplica��o(cuidado)
            services.AddSingleton<IOperacaoSingleton, Operacao>();
            services.AddSingleton<IOperacaoSingletonIntance>(new Operacao(Guid.Empty));

            services.AddTransient<OperacaoService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllerRoute(
                    name: "modulos",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );

                // Mapeamento generico para todas as areas.
                // endPoints.MapControllerRoute(name: "modulos", pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endPoints.MapAreaControllerRoute("AreaProdutos", "Produtos", "Produtos/{controller=Cadastro}/{action=Index}/{id?}");
                endPoints.MapAreaControllerRoute("AreaVendas", "Vendas", "Vendas/{controller=Pedidos}/{action=Index}/{id?}");
            });
        }
    }
}