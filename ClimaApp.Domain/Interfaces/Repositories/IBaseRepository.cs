namespace ClimaApp.Domain.Interfaces.Repositories;

/// <summary>
/// Interface para reposittórios.
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IBaseRepository<TEntity> where TEntity : class
{
    Task AddAsync(TEntity entity);
    Task<TEntity> GetById(int id);
    Task<List<TEntity>> GetAllAsync();
}
