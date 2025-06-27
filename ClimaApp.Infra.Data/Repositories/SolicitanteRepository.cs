using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Infra.Data.Contexts;

namespace ClimaApp.Infra.Data.Repositories;

/// <summary>
/// Classe de repositório para a entidade Solicitante.
/// </summary>
public class SolicitanteRepository : BaseRepository<Solicitante>, ISolicitanteRepository
{
    public SolicitanteRepository(DataContext context) : base(context)
    {
    }
}