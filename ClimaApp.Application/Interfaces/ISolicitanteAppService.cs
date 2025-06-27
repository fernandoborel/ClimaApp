using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Dtos.Response;
using ClimaApp.Domain.Entities;

namespace ClimaApp.Application.Interfaces;

public interface ISolicitanteAppService
{
    Task<SolicitanteResponse> Adicionar(SolicitanteRequest request);
    Task<List<Solicitante>> ObterTodos();
    Task<Solicitante> ObterPorId(int id);
}