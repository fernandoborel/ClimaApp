using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Dtos.Response;
using ClimaApp.Domain.Entities;

namespace ClimaApp.Application.Interfaces;

public interface IRelatorioAppService
{
    Task<RelatorioResponse> Adicionar(RelatorioRequest request);
    Task<List<Relatorio>> ObterTodos();
}