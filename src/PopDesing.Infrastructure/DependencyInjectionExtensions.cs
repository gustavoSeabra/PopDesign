using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopDesing.Domain.Repositories;
using PopDesing.Infrastructure.Repositories;

namespace PopDesing.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApiDependencyGroup(this IServiceCollection services, IConfiguration configuration)
    {
        // Services
        

        // Repositórios
        services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
        
        return services;
    }
}
