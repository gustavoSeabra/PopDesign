namespace PopLume.Domain.Precificacao;

public static class CalculadoraPrecificacao
{
    public static ResultadoPrecificacao Calcular(ParametrosPrecificacao parametros)
    {
        ArgumentNullException.ThrowIfNull(parametros);

        Validar(parametros);

        var horasImpressao = parametros.TempoImpressaoMinutos / 60m;
        var horasMaoDeObra = parametros.TempoMaoDeObraMinutos / 60m;
        var custoFilamentos = SomarItens(parametros.Filamentos, nameof(parametros.Filamentos));
        var custoInsumos = SomarItens(parametros.Insumos, nameof(parametros.Insumos));
        var custoComponentes = SomarItens(parametros.Componentes, nameof(parametros.Componentes));
        var consumoKwh = parametros.PotenciaWatts * horasImpressao / 1000m;
        var custoEnergia = consumoKwh * parametros.ValorKwh;
        var custoEquipamento = horasImpressao * parametros.CustoDepreciacaoHora;
        var custoMaoDeObra = horasMaoDeObra * parametros.ValorMaoDeObraHora;
        var custoTotalLote = custoFilamentos + custoInsumos + custoComponentes
            + custoEnergia + custoEquipamento + custoMaoDeObra;
        var custoUnitario = custoTotalLote / parametros.QuantidadeProduzida;
        var margem = parametros.MargemPercentual / 100m;
        var comissao = parametros.ComissaoPercentual / 100m;
        var divisor = 1m - margem - comissao;

        if (divisor <= 0)
            throw new InvalidOperationException("A soma da margem e da comissão deve ser menor que 100%.");

        var precoSemArredondamento = (custoUnitario + parametros.TaxaFixa) / divisor;
        var precoVenda = decimal.Round(precoSemArredondamento, 2, MidpointRounding.AwayFromZero);
        var valorComissao = precoVenda * comissao;
        var lucroUnitario = precoVenda - custoUnitario - parametros.TaxaFixa - valorComissao;

        return new ResultadoPrecificacao(
            custoFilamentos,
            custoInsumos,
            custoComponentes,
            custoEnergia,
            custoEquipamento,
            custoMaoDeObra,
            custoTotalLote,
            custoUnitario,
            valorComissao,
            parametros.TaxaFixa,
            lucroUnitario,
            precoVenda);
    }

    private static decimal SomarItens(IEnumerable<ItemCusto> itens, string nomeParametro)
    {
        decimal total = 0;
        foreach (var item in itens)
        {
            if (item.Quantidade <= 0)
                throw new ArgumentOutOfRangeException(nomeParametro, "A quantidade de um item deve ser maior que zero.");
            if (item.ValorUnitario < 0)
                throw new ArgumentOutOfRangeException(nomeParametro, "O valor unitário não pode ser negativo.");
            total += item.Total;
        }

        return total;
    }

    private static void Validar(ParametrosPrecificacao parametros)
    {
        ArgumentNullException.ThrowIfNull(parametros.Filamentos);
        ArgumentNullException.ThrowIfNull(parametros.Insumos);
        ArgumentNullException.ThrowIfNull(parametros.Componentes);

        if (parametros.QuantidadeProduzida <= 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.QuantidadeProduzida));
        if (parametros.TempoImpressaoMinutos < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.TempoImpressaoMinutos));
        if (parametros.TempoMaoDeObraMinutos < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.TempoMaoDeObraMinutos));
        if (parametros.PotenciaWatts < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.PotenciaWatts));
        if (parametros.ValorKwh < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.ValorKwh));
        if (parametros.CustoDepreciacaoHora < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.CustoDepreciacaoHora));
        if (parametros.ValorMaoDeObraHora < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.ValorMaoDeObraHora));
        if (parametros.MargemPercentual is < 0 or >= 100)
            throw new ArgumentOutOfRangeException(nameof(parametros.MargemPercentual));
        if (parametros.ComissaoPercentual is < 0 or >= 100)
            throw new ArgumentOutOfRangeException(nameof(parametros.ComissaoPercentual));
        if (parametros.TaxaFixa < 0)
            throw new ArgumentOutOfRangeException(nameof(parametros.TaxaFixa));
    }
}
