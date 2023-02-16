using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        return $"Produto {id}";
    }
}
