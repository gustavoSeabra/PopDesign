﻿using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PopDesing.Domain.Repositories;
using PopDesing.Application.Services.Interfaces;
using PopDesing.Application.Services;
using PopDesing.Infrastructure.Repositories;

namespace PopDesing.Infrastructure;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddApiDependencyGroup(this IServiceCollection services, IConfiguration configuration)
    {
        // Services
        services.AddScoped<IProdutoService, ProdutoService>();
        services.AddScoped<IEquipamentoService, EquipamentoService>();

        // Repositórios
        services.AddScoped<IEquipamentoRepository, EquipamentoRepository>();
        services.AddScoped<IProdutoRepository, ProdutoRepository>();

        return services;
    }
}
