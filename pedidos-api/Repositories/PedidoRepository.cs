using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;

namespace pedidos_api.Models
{
  public class PedidoRepository : IPedidoRepository
  {
    private IDbConnection _db;

    public PedidoRepository(IDbConnection db)
    {
      _db = db;
    }

    public void Add(Pedido item)
    {
      var sql = "INSERT INTO Pedidos (NomeCliente, DataPedido) VALUES (@NomeCliente, @DataPedido)";
      _db.Execute(sql, item);
    }

    public void Delete(int id)
    {
      var sql = "DELETE FROM Pedidos WHERE Id = @Id";
      _db.Execute(sql, new { Id = id });
    }

    public IEnumerable<Pedido> GetAll()
    {
      var sql = "SELECT * FROM Pedidos";
      return _db.Query<Pedido>(sql);
    }

    public Pedido GetById(int id)
    {
      var sql = "SELECT * FROM Pedidos WHERE Id = @Id";
      return _db.Query<Pedido>(sql, new { Id = id }).FirstOrDefault();
    }

    public void Update(Pedido item)
    {
      var sql = "UPDATE Pedidos SET NomeCliente = @NomeCliente, DataPedido = @DataPedido WHERE Id = @Id";
      _db.Execute(sql, item);
    }
  }
}