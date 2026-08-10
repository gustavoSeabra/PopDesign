using PopLume.Domain.Entities;

namespace PopLume.Domain.Precificacao;

public static class ValidadorFaixasMarketplace
{
    public static bool PossuiSobreposicao(IEnumerable<TaxasMarketplace> taxas)
    {
        var ordenadas = taxas.OrderBy(x => x.ValorInicial).ToArray();
        for (var i = 1; i < ordenadas.Length; i++)
        {
            var anterior = ordenadas[i - 1];
            var atual = ordenadas[i];
            if (!anterior.ValorFinal.HasValue || atual.ValorInicial <= anterior.ValorFinal.Value)
                return true;
        }

        return false;
    }
}
