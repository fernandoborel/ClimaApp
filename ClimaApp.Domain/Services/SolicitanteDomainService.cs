using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Repositories;
using ClimaApp.Domain.Interfaces.Services;

namespace ClimaApp.Domain.Services;

/// <summary>
/// Classe de dominio para serviços relacionados a solicitantes.
/// </summary>
/// <param name="unitOfWork"></param>
public class SolicitanteDomainService(IUnitOfWork unitOfWork) : ISolicitanteDomainService
{
    public async Task<Solicitante> Adicionar(Solicitante solicitante)
    {
        await unitOfWork.SolicitanteRepository.AddAsync(solicitante);
        return solicitante;
    }

    public async Task<Solicitante> ObterPorId(int id)
    {
        return await unitOfWork.SolicitanteRepository.GetById(id);
    }

    public async Task<List<Solicitante>> ObterTodos()
    {
        return await unitOfWork.SolicitanteRepository.GetAllAsync();
    }
}