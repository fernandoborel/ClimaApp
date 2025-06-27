using ClimaApp.Application.Interfaces;
using ClimaApp.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ClimaApp.Application.Extensions;

public static class ApplicationServicesExtension
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IRelatorioAppService, RelatorioAppService>();
        services.AddScoped<ISolicitanteAppService, SolicitanteAppService>();

        return services;
    }
}