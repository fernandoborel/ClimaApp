using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Dtos.Response;
using ClimaApp.Application.Interfaces;
using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Services;

namespace ClimaApp.Application.Services;

public class SolicitanteAppService(ISolicitanteDomainService _solicitanteDomainService) : ISolicitanteAppService
{
    public async Task<SolicitanteResponse> Adicionar(SolicitanteRequest request)
    {
        var solicitante = new Solicitante
        {
            Nome = request.Nome
        };

        var solicitanteAdicionado = await _solicitanteDomainService.Adicionar(solicitante);

        return new SolicitanteResponse
        {
            Id = solicitanteAdicionado.Id,
            Nome = solicitanteAdicionado.Nome
        };
    }

    public async Task<Solicitante> ObterPorId(int id)
    {
        return await _solicitanteDomainService.ObterPorId(id);
    }

    public async Task<List<Solicitante>> ObterTodos()
    {
        return await _solicitanteDomainService.ObterTodos();
    }
}