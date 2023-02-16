using System.Collections.Generic;

public interface IUsuarioRepository
{
  IEnumerable<Usuario> GetAll();

}