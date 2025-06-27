using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Infra.Data.Contexts;
using ClimaApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace InfoDengueApp.Infra.Data.Repositories;

public class UnitOfWork(DataContext _context) : IUnitOfWork
{
    private IDbContextTransaction _transaction;


    public void BeginTransaction()
    {
        _transaction = _context.Database.BeginTransaction();
    }

    public void Commit()
    {
        _transaction?.Commit();
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context?.Dispose();
    }

    public void Rollback()
    {
        _transaction?.Rollback();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

    public IRelatorioRepository RelatorioRepository => new RelatorioRepository(_context);

    public ISolicitanteRepository SolicitanteRepository => new SolicitanteRepository(_context);
}