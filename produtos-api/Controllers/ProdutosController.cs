using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{

  private IProdutoRepository _produtoRepository;
  public ProdutosController(IProdutoRepository produtoRepository)
  {
    _produtoRepository = produtoRepository;

  }

  [HttpGet]
  public IEnumerable<Produto> GetAll()
  {
    return _produtoRepository.GetAll();
  }
}
