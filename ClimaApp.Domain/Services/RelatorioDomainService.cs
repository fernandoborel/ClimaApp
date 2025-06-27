using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Repositories;

namespace ClimaApp.Domain.Services;

/// <summary>
/// Classe de dominio para serviços relacionados a relatórios.
/// </summary>
public class RelatorioDomainService(IUnitOfWork unitOfWork) : IRelatorioDomainService
{
    public async Task<Relatorio> Adicionar(Relatorio relatorio)
    {
        await unitOfWork.RelatorioRepository.AddAsync(relatorio);
        return relatorio;
    }

    public async Task<Relatorio> ObterPorId(int id)
    {
        return await unitOfWork.RelatorioRepository.GetById(id);
    }

    public async Task<List<Relatorio>> ObterTodos()
    {
        return await unitOfWork.RelatorioRepository.GetAllAsync();
    }
}