namespace PopLume.Domain.Precificacao;

public sealed record ItemCusto(
    string Descricao,
    decimal Quantidade,
    decimal ValorUnitario)
{
    public decimal Total => Quantidade * ValorUnitario;
}
