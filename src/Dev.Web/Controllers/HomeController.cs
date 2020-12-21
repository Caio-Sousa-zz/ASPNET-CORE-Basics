using Dev.Web.Data;
using Dev.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Dev.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPedidoRepository _pedidoRepository;

        public OperacaoService OperacaoService { get; }
        public OperacaoService OperacaoService2 { get; }

        public HomeController(OperacaoService operacaoService, OperacaoService operacaoService2)
        {
            OperacaoService = operacaoService;
            OperacaoService2 = operacaoService2;
        }

        public string Index()
        {
            return "1º instância: " + Environment.NewLine +
                    OperacaoService.Transient.OperacaoId + Environment.NewLine +
                    OperacaoService.Scoped.OperacaoId + Environment.NewLine +
                    OperacaoService.Singleton.OperacaoId + Environment.NewLine +
                    OperacaoService.SingleTonInstance.OperacaoId + Environment.NewLine +

                    Environment.NewLine +
                    Environment.NewLine +

                    "2º instância: " + Environment.NewLine +
                    OperacaoService2.Transient.OperacaoId + Environment.NewLine +
                    OperacaoService2.Scoped.OperacaoId + Environment.NewLine +
                    OperacaoService2.Singleton.OperacaoId + Environment.NewLine +
                    OperacaoService2.SingleTonInstance.OperacaoId + Environment.NewLine;
        }

        ///// <summary>
        ///// Quando criar uma instancia da controller precisa passar Ipedido repository no ctor.
        ///// O MVC ja faz essa parte no startup.cs via services.AddTransient<IPedidoRepository, PedidoRepository>();
        ///// </summary>
        ///// <param name="pedidoRepository"></param>
        //public HomeController(IPedidoRepository pedidoRepository)
        //{
        //    _pedidoRepository = pedidoRepository;
        //}

        //public IActionResult Index()
        //{
        //    // Aclopamneto
        //    //var repor = new PedidoRepository();
        //    //var pedido = repor.GetPedido();

        //    var pedido = _pedidoRepository.GetPedido();

        //    return View();
        //}

        ///// <summary>
        ///// Obter injecção de dep via parametro, caso sistema legado
        ///// </summary>
        ///// <param name="_pedidoRepository2"></param>
        ///// <returns></returns>
        //public IActionResult Pedido([FromServices] IPedidoRepository _pedidoRepository2)
        //{
        //    var pedido = _pedidoRepository2.GetPedido();

        //    return View();
        //}
    }
}