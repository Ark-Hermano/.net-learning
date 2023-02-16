using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace pedidos_api.Models
{
  public class ProdutoRepository : IProdutoRepository
  {
    private IDbConnection _db;

    public ProdutoRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Produto> GetAll()
    {
      var sql = "SELECT * FROM Produtos";
      return _db.Query<Produto>(sql);
    }

  }
}