namespace PopLume.Domain.Precificacao;

public sealed record ParametrosPrecificacao(
    IReadOnlyCollection<ItemCusto> Filamentos,
    IReadOnlyCollection<ItemCusto> Insumos,
    IReadOnlyCollection<ItemCusto> Componentes,
    int TempoImpressaoMinutos,
    int TempoMaoDeObraMinutos,
    int PotenciaWatts,
    decimal ValorKwh,
    decimal CustoDepreciacaoHora,
    decimal ValorMaoDeObraHora,
    decimal MargemPercentual,
    decimal ComissaoPercentual = 0m,
    decimal TaxaFixa = 0m,
    int QuantidadeProduzida = 1);
