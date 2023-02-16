using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace pedidos_api.Models
{
  public class UsuarioRepository : IUsuarioRepository
  {
    private IDbConnection _db;

    public UsuarioRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Usuario> GetAll()
    {
      var sql = "SELECT * FROM Usuarios";
      return _db.Query<Usuario>(sql);
    }

  }
}