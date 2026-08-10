using PopLume.Domain.Entities;

namespace PopLume.Domain.Precificacao;

public static class SeletorTaxaMarketplace
{
    public static (TaxasMarketplace? Taxa, ResultadoPrecificacao Resultado) Selecionar(
        IEnumerable<TaxasMarketplace> taxas,
        ParametrosPrecificacao parametros)
    {
        ArgumentNullException.ThrowIfNull(taxas);

        ResultadoPrecificacao? ultimo = null;
        foreach (var taxa in taxas.OrderBy(x => x.ValorInicial))
        {
            ultimo = CalculadoraPrecificacao.Calcular(parametros with
            {
                ComissaoPercentual = taxa.ComissaoPercentual,
                TaxaFixa = taxa.TaxaFixa
            });
            if (taxa.Contem(ultimo.PrecoVenda))
                return (taxa, ultimo);
        }

        return (null, ultimo ?? CalculadoraPrecificacao.Calcular(parametros));
    }
}
