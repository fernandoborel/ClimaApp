using ClimaApp.Domain.Entities;

namespace ClimaApp.Domain.Interfaces.Services;

public interface ISolicitanteDomainService
{
    Task<Solicitante> Adicionar(Solicitante solicitante);
    Task<List<Solicitante>> ObterTodos();
    Task<Solicitante> ObterPorId(int id);
}