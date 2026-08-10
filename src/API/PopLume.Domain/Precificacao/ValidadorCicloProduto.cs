using PopLume.Domain.Entities;

namespace PopLume.Domain.Precificacao;

public static class ValidadorCicloProduto
{
    public static bool PossuiCiclo(Guid idProdutoPai, Guid idProdutoFilho, IEnumerable<ProdutoComposicao> composicoes)
    {
        if (idProdutoPai == idProdutoFilho)
            return true;

        var filhosPorPai = composicoes
            .GroupBy(x => x.IdProdutoPai)
            .ToDictionary(x => x.Key, x => x.Select(y => y.IdProdutoFilho).ToArray());

        var visitados = new HashSet<Guid>();
        var pendentes = new Stack<Guid>();
        pendentes.Push(idProdutoFilho);

        while (pendentes.TryPop(out var atual))
        {
            if (atual == idProdutoPai)
                return true;
            if (!visitados.Add(atual) || !filhosPorPai.TryGetValue(atual, out var filhos))
                continue;

            foreach (var filho in filhos)
                pendentes.Push(filho);
        }

        return false;
    }
}
