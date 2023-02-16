using System.Collections.Generic;

public interface IPedidoRepository
{
  IEnumerable<Pedido> GetAll();
  Pedido GetById(int id);
  void Add(Pedido item);
  void Update(Pedido item);
  void Delete(int id);
}