using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Infra.Data.Contexts;
using InfoDengueApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClimaApp.Infra.Data.Extensions;

public static class EntityFrameworkExtensions
{
    public static IServiceCollection AddEntityFramework(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<DataContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("DBO_CLIMAAPP"));
        });

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}