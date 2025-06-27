using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Infra.Data.Contexts;

namespace ClimaApp.Infra.Data.Repositories;

/// <summary>
/// Classe de repositorio para a entidade Relatorio.
/// </summary>
public class RelatorioRepository : BaseRepository<Relatorio> ,IRelatorioRepository
{
    public RelatorioRepository(DataContext context) : base(context)
    {
    }
}