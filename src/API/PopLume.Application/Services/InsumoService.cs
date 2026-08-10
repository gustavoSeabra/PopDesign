using Microsoft.Extensions.Logging;
using PopLume.Application.Dtos;
using PopLume.Application.Mappers;
using PopLume.Application.Services.Interfaces;
using PopLume.Domain.Repositories;

namespace PopLume.Application.Services;

public class InsumoService(IInsumoRepository repository, ILogger<InsumoService> logger) : IInsumoService
{
    public async Task<ResultadoDto<IEnumerable<InsumoDto>>> ObterTodosAsync(CancellationToken cancellationToken = default)
    {
        var itens = await repository.ObterTodosAsync(cancellationToken);
        return ResultadoDto<IEnumerable<InsumoDto>>.RetornaSucesso(itens.Select(x => x.ToDto()));
    }

    public async Task<ResultadoDto<InsumoDto?>> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await repository.ObterPorIdAsync(id, cancellationToken);
        return item is null
            ? ResultadoDto<InsumoDto?>.RetornaNaoEncontrado("Insumo não encontrado.")
            : ResultadoDto<InsumoDto?>.RetornaSucesso(item.ToDto());
    }

    public async Task<ResultadoDto<Guid>> AdicionarAsync(CreateInsumoDto dto, CancellationToken cancellationToken = default)
    {
        try
        {
            var item = dto.ToEntity();
            repository.Adicionar(item);
            await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
            return ResultadoDto<Guid>.RetornaSucesso(item.IdInsumo);
        }
        catch (Exception ex)
        {
            logger.LogError(ex, "Erro ao cadastrar insumo.");
            return ResultadoDto<Guid>.RetornaErro("Não foi possível cadastrar o insumo.");
        }
    }

    public async Task<ResultadoDto<bool>> AtualizarAsync(UpdateInsumoDto dto, CancellationToken cancellationToken = default)
    {
        var item = await repository.ObterPorIdAsync(dto.IdInsumo, cancellationToken);
        if (item is null)
            return ResultadoDto<bool>.RetornaNaoEncontrado("Insumo não encontrado.");
        item.Nome = dto.Nome;
        item.ValorCompra = dto.ValorCompra!.Value;
        item.QuantidadeComprada = dto.QuantidadeComprada!.Value;
        item.UnidadeMedida = dto.UnidadeMedida!.Value;
        repository.Atualizar(item);
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return ResultadoDto<bool>.RetornaSucesso(true);
    }

    public async Task<ResultadoDto<bool>> RemoverAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var item = await repository.ObterPorIdAsync(id, cancellationToken);
        if (item is null)
            return ResultadoDto<bool>.RetornaNaoEncontrado("Insumo não encontrado.");
        repository.Remover(item);
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return ResultadoDto<bool>.RetornaSucesso(true);
    }
}
