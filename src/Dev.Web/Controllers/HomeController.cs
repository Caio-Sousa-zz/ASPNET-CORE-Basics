using Dev.Web.Data;
using Microsoft.AspNetCore.Mvc;

namespace Dev.Web.Controllers
{
    public class HomeController : Controller
    {
        private IPedidoRepository _pedidoRepository;

        /// <summary>
        /// Quando criar uma instancia da controller precisa passar Ipedido repository no ctor.
        /// O MVC ja faz essa parte no startup.cs via services.AddTransient<IPedidoRepository, PedidoRepository>();
        /// </summary>
        /// <param name="pedidoRepository"></param>
        public HomeController(IPedidoRepository pedidoRepository)
        {
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Index()
        {
            // Aclopamneto
            //var repor = new PedidoRepository();
            //var pedido = repor.GetPedido();

            var pedido = _pedidoRepository.GetPedido();

            return View();
        }

        /// <summary>
        /// Obter injecção de dep via parametro, caso sistema legado
        /// </summary>
        /// <param name="_pedidoRepository2"></param>
        /// <returns></returns>
        public IActionResult Pedido([FromServices] IPedidoRepository _pedidoRepository2)
        {
            var pedido = _pedidoRepository2.GetPedido();

            return View();
        }
    }
}