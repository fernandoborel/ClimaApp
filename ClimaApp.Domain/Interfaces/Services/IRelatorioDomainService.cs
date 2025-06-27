using ClimaApp.Domain.Entities;

public interface IRelatorioDomainService
{
    Task<Relatorio> Adicionar(Relatorio relatorio);
    Task<List<Relatorio>> ObterTodos();
    Task<Relatorio> ObterPorId(int id);
}