using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{

  private IUsuarioRepository _usuarioRepository;
  public UsuariosController(IUsuarioRepository usuarioRepository)
  {
    _usuarioRepository = usuarioRepository;

  }


  [HttpGet]
  public IEnumerable<Usuario> GetAll()
  {
    return _usuarioRepository.GetAll();
  }
}
