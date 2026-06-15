using PopDesing.Application.Dtos;
using PopDesing.Application.Services.Interfaces;
using PopDesing.Domain.Repositories;
using PopDesing.Domain.Entities;
using PopDesing.Application.Mappers;

namespace PopDesing.Application.Services;

public class ProdutoService : IProdutoService
{
    private readonly IProdutoRepository _produtoRepository;

    public ProdutoService(IProdutoRepository produtoRepository)
    {
        _produtoRepository = produtoRepository;
    }

    public async Task<ResultadoDto<IEnumerable<ProdutoDto>>> ObterTodosAsync(CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepository.ObterTodosProdutosAsync(cancellationToken);
        var dtos = produtos.Select(p => p.ToDto());
        return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaSucesso(dtos);
    }

    public async Task<ResultadoDto<ProdutoDto?>> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var produto = await _produtoRepository.ObterProdutosPorIdAsync(id, cancellationToken);
        
        if (produto == null)
            return ResultadoDto<ProdutoDto?>.RetornaNaoEncontrado("Produto não encontrado");

        return ResultadoDto<ProdutoDto?>.RetornaSucesso(produto.ToDto());
    }

    public async Task<ResultadoDto<IEnumerable<ProdutoDto>>> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default)
    {
        var produtos = await _produtoRepository.ObterProdutosPorNomeAsync(nome, cancellationToken);
        var dtos = produtos.Select(p => p.ToDto());
        return ResultadoDto<IEnumerable<ProdutoDto>>.RetornaSucesso(dtos);
    }

    public async Task<ResultadoDto<Guid>> AdicionarAsync(CreateProdutoDto dto, CancellationToken cancellationToken = default)
    {
        var produto = dto.ToEntity();

        _produtoRepository.Adicionar(produto);
        await _produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return ResultadoDto<Guid>.RetornaSucesso(produto.IdProduto);
    }

    public async Task<ResultadoDto<bool>> AtualizarAsync(UpdateProdutoDto dto, CancellationToken cancellationToken = default)
    {
        var produtoExistente = await _produtoRepository.ObterProdutosPorIdAsync(dto.IdProduto, cancellationToken);

        if (produtoExistente == null)
            return ResultadoDto<bool>.RetornaNaoEncontrado("Produto não encontrado para atualização.");

        // Atualiza propriedades básicas
        produtoExistente.Nome = dto.Nome;
        produtoExistente.PrecoCusto = dto.PrecoCusto;
        produtoExistente.QuantidadeFilamento = dto.QuantidadeFilamento;
        produtoExistente.TempoImpressao = dto.TempoImpressao;

        // Atualiza Composição (simplificado: remove e adiciona)
        produtoExistente.ComposicoesPai.Clear();
        if (dto.Componentes != null)
        {
            foreach (var comp in dto.Componentes)
            {
                produtoExistente.ComposicoesPai.Add(new ProdutoComposicao { IdProdutoFilho = comp.IdProdutoFilho, Quantidade = comp.Quantidade });
            }
        }

        _produtoRepository.Atualizar(produtoExistente);
        await _produtoRepository.UnitOfWork.SaveChangesAsync(cancellationToken);

        return ResultadoDto<bool>.RetornaSucesso("Produto atualizado com sucesso.");
    }
}
