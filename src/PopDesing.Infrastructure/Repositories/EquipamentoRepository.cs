using Microsoft.EntityFrameworkCore;
using PopDesing.Domain.Entities;
using PopDesing.Domain.Repositories;
using PopDesing.Infrastructure.DataProvider.Context;

namespace PopDesing.Infrastructure.Repositories;

public class EquipamentoRepository : BaseRepository<Equipamento>, IEquipamentoRepository
{
    public EquipamentoRepository(PopDesingDbContext dbContext) : base(dbContext)
    {
    }

    public override void Remover(Equipamento equipamento)
    {
        equipamento.Excluir();
        dbContext.Set<Equipamento>().Update(equipamento);
    }

    public async Task<IEnumerable<Equipamento>> ObterEquipamentosPorApelidoAsync(string apelido, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Equipamento>()
            .Where(e => e.Apelido.Contains(apelido))
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    

    public async Task<Equipamento?> ObterEquipamentosPorIdAsync(Guid idEquipamento, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Equipamento>()
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.IdEquipamento == idEquipamento, cancellationToken);

    public async Task<IEnumerable<Equipamento>> ObterEquipamentosDesativadosAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<Equipamento>()
            .IgnoreQueryFilters()
            .Where(e => e.Excluido)
            .AsNoTracking()
            .ToListAsync(cancellationToken);

    public async Task<IEnumerable<Equipamento>> ObterEquipamentosPorNomeAsync(string nome, CancellationToken cancellationToken = default) =>
        await dbContext.Set<Equipamento>()
            .Where(e => e.Nome.Contains(nome))
            .AsNoTracking()
            .ToListAsync(cancellationToken);


    public async Task<IEnumerable<Equipamento>> ObterTodosEquipamentosAsync(CancellationToken cancellationToken = default) =>
        await dbContext.Set<Equipamento>()
            .AsNoTracking()
            .ToListAsync(cancellationToken);
}
