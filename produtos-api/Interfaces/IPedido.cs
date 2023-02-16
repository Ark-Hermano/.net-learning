using Refit;

public class Pedido
{
  public int Id { get; set; }
  public string ProdutoId { get; set; }
  public string UserId { get; set; }
  public DateTime DataCriacao { get; set; }
}


public interface IPedidoApi
{
  [Post("/api/pedidos")]
  Task<Pedido> CriarPedido([Body] Pedido pedido);
}