using Microsoft.EntityFrameworkCore;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Infrastructure.DataProvider.Context;

namespace PopLume.Infrastructure.Repositories;

public class InsumoRepository(PopLumeDbContext dbContext) : BaseRepository<Insumo>(dbContext), IInsumoRepository
{
    public override void Remover(Insumo insumo)
    {
        insumo.Excluir();
        dbContext.Set<Insumo>().Update(insumo);
    }

    public async Task<IEnumerable<Insumo>> ObterTodosAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<Insumo>().AsNoTracking().ToListAsync(cancellationToken);

    public async Task<Insumo?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Insumo>().FirstOrDefaultAsync(x => x.IdInsumo == id, cancellationToken);

    public async Task<IEnumerable<Insumo>> ObterPorNomeAsync(string nome, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Insumo>()
            .Where(x => EF.Functions.ILike(x.Nome, CriarPadraoBusca(nome), LikeEscapeCharacter))
            .AsNoTracking().ToListAsync(cancellationToken);
}
