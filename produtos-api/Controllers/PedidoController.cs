using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;


namespace pedidos_api.Controllers
{
  [ApiController]
  [Route("api/pedidos")]
  public class PedidosController : ControllerBase
  {
    private readonly IPedidoApi _pedidosApi;
    public PedidosController(IPedidoApi pedidosApi)
    {
      _pedidosApi = pedidosApi;

    }

    [HttpPost]
    public async Task<ActionResult<Pedido>> Post([FromBody] Pedido pedido)
    {
      var novoPedido = new Pedido
      {
        ProdutoId = pedido.ProdutoId,
        UserId = pedido.UserId,
        DataCriacao = DateTime.Now
      };

      var resultado = await _pedidosApi.CriarPedido(novoPedido);

      return resultado;
    }


  }
}
