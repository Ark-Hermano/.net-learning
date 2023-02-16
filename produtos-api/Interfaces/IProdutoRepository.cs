using System.Collections.Generic;

public interface IProdutoRepository
{
  IEnumerable<Produto> GetAll();

}