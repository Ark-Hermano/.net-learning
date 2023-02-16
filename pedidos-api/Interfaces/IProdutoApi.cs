using Refit;

public interface IProdutosApi
{
    [Get("/api/produtos/{id}")]
    Task<string> ObterProduto(int id);
}