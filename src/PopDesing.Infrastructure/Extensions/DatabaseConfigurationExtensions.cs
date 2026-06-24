using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopDesing.Infrastructure.DataProvider.Context;

namespace PopDesing.Infrastructure.Extensions;

public static class DatabaseConfigurationExtensions
{
    public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
    {
        return services.AddDbContext<PopDesingDbContext>(options =>
        {
            var connectionString = configuration.GetConnectionString("PopDesingApi");
            options.UseNpgsql(
                connectionString,
                sqlOptions => sqlOptions
                    .CommandTimeout(60)
                    .EnableRetryOnFailure(maxRetryCount: 10, maxRetryDelay: TimeSpan.FromSeconds(60), null)
            );
        });
    }
}
