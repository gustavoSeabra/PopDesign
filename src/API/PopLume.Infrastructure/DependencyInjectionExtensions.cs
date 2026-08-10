﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopLume.Domain.Repositories;
using PopLume.Application.Services.Interfaces;
using PopLume.Application.Services;
using PopLume.Infrastructure.Repositories;

namespace PopLume.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApiDependencyGroup(this IServiceCollection services, IConfiguration configuration)
    {
        // Services
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IEquipamentoService, EquipamentoService>();
        services.AddScoped<IMarketplaceService, MarketplaceService>();
        services.AddScoped<IFilamentoService, FilamentoService>();
        services.AddScoped<IInsumoService, InsumoService>();
        services.AddScoped<ITarifaEnergiaService, TarifaEnergiaService>();
        services.AddScoped<ICustoMaoDeObraService, CustoMaoDeObraService>();
        services.AddScoped<IPrecificacaoService, PrecificacaoService>();

        // Repositórios
        services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();
        services.AddScoped<IMarketplaceRepository, MarketplaceRepository>();
        services.AddScoped<IFilamentoRepository, FilamentoRepository>();
        services.AddScoped<IInsumoRepository, InsumoRepository>();
        services.AddScoped<ITarifaEnergiaRepository, TarifaEnergiaRepository>();
        services.AddScoped<ICustoMaoDeObraRepository, CustoMaoDeObraRepository>();
        services.AddScoped<IFichaPrecificacaoRepository, FichaPrecificacaoRepository>();

        return services;
    }
}
