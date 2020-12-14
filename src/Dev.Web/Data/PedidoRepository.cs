using Dev.Web.Models;

namespace Dev.Web.Data
{
    public class PedidoRepository : IPedidoRepository
    {
        public Pedido GetPedido()
        {
            return new Pedido();
        }
    }
}

public interface IPedidoRepository
{
    Pedido GetPedido();
}
