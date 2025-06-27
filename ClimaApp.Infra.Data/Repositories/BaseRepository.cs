using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ClimaApp.Infra.Data.Repositories;

/// <summary>
/// Modelo base para repositórios.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly DataContext _context;

    public BaseRepository(DataContext context)
    {
        _context = context;
    }

    public virtual async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public virtual async Task<List<TEntity>> GetAllAsync()
    {
        return await _context.Set<TEntity>().ToListAsync();
    }

    public virtual async Task<TEntity> GetById(int id)
    {
        return await _context.Set<TEntity>().FindAsync(id);
    }
}