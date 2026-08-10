using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;

namespace PopLume.Application.Services;

public class CustoMaoDeObraService(ICustoMaoDeObraRepository repository) : ICustoMaoDeObraService
{
    public async Task<ResultadoDto<IEnumerable<CustoMaoDeObraDto>>> ObterTodosAsync(CancellationToken cancellationToken = default) =>
        ResultadoDto<IEnumerable<CustoMaoDeObraDto>>.RetornaSucesso((await repository.ObterTodosAsync(cancellationToken)).Select(Mapear));

    public async Task<ResultadoDto<CustoMaoDeObraDto?>> ObterVigenteAsync(CancellationToken cancellationToken = default)
    {
        var item = await repository.ObterVigenteAsync(DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
        return item is null ? ResultadoDto<CustoMaoDeObraDto?>.RetornaNaoEncontrado("Não existe custo de mão de obra vigente.")
            : ResultadoDto<CustoMaoDeObraDto?>.RetornaSucesso(Mapear(item));
    }

    public async Task<ResultadoDto<Guid>> AdicionarAsync(CreateCustoMaoDeObraDto dto, CancellationToken cancellationToken = default)
    {
        if (await repository.ExisteSobreposicaoAsync(dto.InicioVigencia!.Value, dto.FimVigencia, cancellationToken: cancellationToken))
            return ResultadoDto<Guid>.RetornaErro("A vigência informada se sobrepõe a outro custo de mão de obra.");
        var item = new CustoMaoDeObra { ValorHora = dto.ValorHora!.Value, InicioVigencia = dto.InicioVigencia.Value, FimVigencia = dto.FimVigencia };
        repository.Adicionar(item);
        await repository.UnitOfWork.SaveChangesAsync(cancellationToken);
        return ResultadoDto<Guid>.RetornaSucesso(item.IdCustoMaoDeObra);
    }

    private static CustoMaoDeObraDto Mapear(CustoMaoDeObra x) => new() { IdCustoMaoDeObra = x.IdCustoMaoDeObra, ValorHora = x.ValorHora, InicioVigencia = x.InicioVigencia, FimVigencia = x.FimVigencia };
}
