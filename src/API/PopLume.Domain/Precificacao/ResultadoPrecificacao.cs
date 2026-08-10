namespace PopLume.Domain.Precificacao;

public sealed record ResultadoPrecificacao(
    decimal CustoFilamentos,
    decimal CustoInsumos,
    decimal CustoComponentes,
    decimal CustoEnergia,
    decimal CustoEquipamento,
    decimal CustoMaoDeObra,
    decimal CustoTotalLote,
    decimal CustoUnitario,
    decimal ValorComissao,
    decimal TaxaFixa,
    decimal LucroUnitario,
    decimal PrecoVenda);
