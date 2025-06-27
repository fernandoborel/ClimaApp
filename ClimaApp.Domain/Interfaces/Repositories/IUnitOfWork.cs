namespace ClimaApp.Domain.Interfaces.Repositories;

public interface IUnitOfWork : IDisposable
{
    Task SaveChangesAsync();
    void BeginTransaction();
    void Commit();
    void Rollback();

    IRelatorioRepository RelatorioRepository { get; }
    ISolicitanteRepository SolicitanteRepository { get; }
}