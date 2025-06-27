using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Services;
using ClimaApp.Domain.Services;
using ClimaApp.Domain.Validations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ClimaApp.Domain.Extensions;

public static class DomainServicesExtension
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services)
    {
        services.AddScoped<IRelatorioDomainService, RelatorioDomainService>();
        services.AddScoped<ISolicitanteDomainService, SolicitanteDomainService>();
        services.AddScoped<IValidator<Relatorio>, RelatorioValidation>();
        services.AddScoped<IValidator<Solicitante>, SolicitanteValidation>();

        return services;
    }
}