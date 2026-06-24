using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopDesign.Infrastructure.DataProvider.Context;

namespace PopDesign.Infrastructure.Extensions;

public static class DatabaseConfigurationExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<PopDesignDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("PopDesignApi");
            options.UseNpgsql(
                connectionString,
                sqlOptions => sqlOptions
                    .CommandTimeout(60)
                    .EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(60), null)
            );
        });
    }
}
