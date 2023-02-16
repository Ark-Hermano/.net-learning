using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Refit;


namespace pedidos_api.Controllers
{
  [ApiController]
  [Route("api/pedidos")]
  public class PedidosController : ControllerBase
  {
    private IPedidoRepository _pedidoRepository;
    private readonly IProdutosApi _produtosApi;
    public PedidosController(IProdutosApi produtosApi, IPedidoRepository pedidoRepository)
    {
      _produtosApi = produtosApi;
      _pedidoRepository = pedidoRepository;

    }

    [HttpGet("{id}")]
    public async Task<ActionResult<string>> Get(int id)
    {

      try
      {
        var produto = await _produtosApi.ObterProduto(id);
        return $"Pedido {id} - {produto}";
      }
      catch (HttpRequestException ex)
      {
        Console.WriteLine($"URL da requisição: {ex.Message}");
        return StatusCode(500, "Erro ao acessar a API");

      }
    }

    [HttpGet]
    public IEnumerable<Pedido> GetAll()
    {
      return _pedidoRepository.GetAll();
    }

    [HttpGet("{id}/details", Name = "GetPedido")]
    public IActionResult GetById(int id)
    {
      var item = _pedidoRepository.GetById(id);
      if (item == null)
      {
        return NotFound();
      }
      return new ObjectResult(item);
    }

    [HttpPost]
    public IActionResult Create([FromBody] Pedido item)
    {
      if (item == null)
      {
        return BadRequest();
      }
      _pedidoRepository.Add(item);
      return CreatedAtRoute("GetPedido", new { id = item.Id }, item);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, [FromBody] Pedido item)
    {
      if (item == null || item.Id != id)
      {
        return BadRequest();
      }

      var pedido = _pedidoRepository.GetById(id);
      if (pedido == null)
      {
        return NotFound();
      }

      _pedidoRepository.Update(item);
      return new NoContentResult();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
      var pedido = _pedidoRepository.GetById(id);
      if (pedido == null)
      {
        return NotFound();
      }

      _pedidoRepository.Delete(id);
      return new NoContentResult();
    }

  }
}
