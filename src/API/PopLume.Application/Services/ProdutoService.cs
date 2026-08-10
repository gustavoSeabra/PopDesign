using Microsoft.Extensions.Logging;
using PopLume.Application.Dtos;
using PopLume.Application.Mappers;
using PopLume.Application.Services.Interfaces;
using PopLume.Domain.Entities;
using PopLume.Domain.Precificacao;
using PopLume.Domain.Repositories;

namespace PopLume.Application.Services;

public class ProdutoService(IProdutoRepository produtoRepository, ILogger<ProdutoService> logger) : IProdutoService
{
    public async Task<ResultadoDto<IEnumerable<ProdutoDto>>> ObterTodosAsync(CancellationToken cancellationToken = default)
    {
        try
        {
            var produtos = await produtoRepository.ObterTodosProdutosAsync(cancellationToken);
            return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaSucesso(produtos.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao obter todos os produtos.");
            return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaErro("Ocorreu um erro ao recuperar a lista de produtos.");
        }
    }

    public async Task<ResultadoDto<ProdutoDto?>> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        try
        {
            var produto = await produtoRepository.ObterProdutosPorIdAsync(id, cancellationToken);
            return produto is null
                ? ResultadoDto<ProdutoDto?>.RetornaNaoEncontrado("Produto não encontrado.")
                : ResultadoDto<ProdutoDto?>.RetornaSucesso(produto.ToDto());
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao buscar produto {ProdutoId}.", id);
            return ResultadoDto<ProdutoDto?>.RetornaErro("Erro ao buscar o produto.");
        }
    }

    public async Task<ResultadoDto<IEnumerable<ProdutoDto>>> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default)
    {
        try
        {
            var produtos = await produtoRepository.ObterProdutosPorNomeAsync(nome, cancellationToken);
            return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaSucesso(produtos.Select(x => x.ToDto()));
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao pesquisar produtos por nome.");
            return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaErro("Erro ao realizar a busca por nome.");
        }
    }

    public async Task<ResultadoDto<Guid>> AdicionarAsync(CreateProdutoDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var produto = dto.ToEntity();
            produto.IdProduto = Guid.NewGuid();

            var erro = await ValidarComposicoesAsync(produto.IdProduto, produto.ComposicoesPai, cancellationToken);
            if (erro is not null)
                return ResultadoDto<Guid>.RetornaErro(erro);

            produtoRepository.Adicionar(produto);
            await produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ResultadoDto<Guid>.RetornaSucesso(produto.IdProduto);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao adicionar produto {NomeProduto}.", dto.Nome);
            return ResultadoDto<Guid>.RetornaErro("Não foi possível salvar o produto.");
        }
    }

    public async Task<ResultadoDto<bool>> AtualizarAsync(UpdateProdutoDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var produto = await produtoRepository.ObterProdutosPorIdAsync(dto.IdProduto, cancellationToken);
            if (produto is null)
                return ResultadoDto<bool>.RetornaNaoEncontrado("Produto não encontrado para atualização.");

            produto.Nome = dto.Nome;
            produto.TempoImpressaoMinutos = dto.TempoImpressaoMinutos ?? 0;
            produto.TempoMaoDeObraMinutos = dto.TempoMaoDeObraMinutos ?? 0;
            produto.IdEquipamento = dto.IdEquipamento;
            var custosVariacoes = produto.Variacoes.ToDictionary(x => x.IdProdutoVariacao, x => x.PrecoCusto);
            ProdutoMapper.AplicarRelacionamentos(produto, dto.Variacoes, dto.Insumos, dto.Componentes);
            foreach (var variacao in produto.Variacoes.Where(x => custosVariacoes.ContainsKey(x.IdProdutoVariacao)))
                variacao.AtualizarPrecoCusto(custosVariacoes[variacao.IdProdutoVariacao]);

            var erro = await ValidarComposicoesAsync(produto.IdProduto, produto.ComposicoesPai, cancellationToken);
            if (erro is not null)
                return ResultadoDto<bool>.RetornaErro(erro);

            produtoRepository.Atualizar(produto);
            await produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ResultadoDto<bool>.RetornaSucesso("Produto atualizado com sucesso.");
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao atualizar produto {ProdutoId}.", dto.IdProduto);
            return ResultadoDto<bool>.RetornaErro("Erro ao processar a atualização do produto.");
        }
    }

    private async Task<string?> ValidarComposicoesAsync(
        Guid idProduto,
        IEnumerable<ProdutoComposicao> novasComposicoes,
        CancellationToken cancellationToken)
    {
        var existentes = (await produtoRepository.ObterTodasComposicoesAsync(cancellationToken))
            .Where(x => x.IdProdutoPai != idProduto)
            .ToList();

        foreach (var composicao in novasComposicoes)
        {
            if (composicao.Quantidade <= 0)
                return "A quantidade de um produto componente deve ser maior que zero.";

            if (!await produtoRepository.VariacaoPertenceAoProdutoAsync(
                    composicao.IdProdutoFilho,
                    composicao.IdProdutoVariacaoFilho,
                    cancellationToken))
                return "A variação informada não pertence ao produto componente.";

            if (ValidadorCicloProduto.PossuiCiclo(idProduto, composicao.IdProdutoFilho, existentes))
                return "A composição informada criaria um ciclo entre produtos.";

            existentes.Add(new ProdutoComposicao
            {
                IdProdutoPai = idProduto,
                IdProdutoFilho = composicao.IdProdutoFilho,
                Quantidade = composicao.Quantidade
            });
        }

        return null;
    }
}
