using PopLume.Application.Dtos;

namespace PopLume.Application.Services.Interfaces;

public interface IPrecificacaoService
{
    Task<ResultadoDto<PrecificacaoDto>> SimularAsync(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken = default);
    Task<ResultadoDto<PrecificacaoDto>> CalcularESalvarAsync(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken = default);
    Task<ResultadoDto<IEnumerable<PrecificacaoDto>>> ObterHistoricoAsync(Guid idProduto, CancellationToken cancellationToken = default);
}
