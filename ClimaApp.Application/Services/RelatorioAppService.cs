using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Dtos.Response;
using ClimaApp.Application.Interfaces;
using ClimaApp.Domain.Entities;
using ClimaApp.Domain.Interfaces.Services;
using FluentValidation;
using System.Text.Json;

namespace ClimaApp.Application.Services;

public class RelatorioAppService : IRelatorioAppService
{
    private readonly IRelatorioDomainService _relatorioDomainService;
    private readonly ISolicitanteDomainService _solicitanteDomainService;
    private readonly IValidator<Relatorio> _validator;
    private readonly HttpClient _httpClient;

    public RelatorioAppService(IRelatorioDomainService relatorioDomainService, IValidator<Relatorio> validator, HttpClient httpClient, ISolicitanteDomainService solicitanteDomainService)
    {
        _relatorioDomainService = relatorioDomainService;
        _validator = validator;
        _httpClient = httpClient;
        _solicitanteDomainService = solicitanteDomainService;
    }

    public async Task<RelatorioResponse> Adicionar(RelatorioRequest request)
    {
        var (valido, mensagem) = await ValidarRelatorioRequest(request);
        if (!valido)
            throw new ArgumentException(mensagem);

        var relatorio = await ConsultarApi(request);

        var relatorioSalvo = await _relatorioDomainService.Adicionar(relatorio);

        return new RelatorioResponse
        {
            Id = relatorioSalvo.Id,
            Cidade = relatorioSalvo.Cidade,
            Pais = relatorioSalvo.Pais,
            Temperatura = relatorioSalvo.Temperatura,
            Condicao = relatorioSalvo.Condicao,
            VelocidadeVento = relatorioSalvo.VelocidadeVento,
            DataHora = relatorioSalvo.DataHora,
            SolicitanteId = request.SolicitanteId
        };
    }

    public async Task<List<Relatorio>> ObterTodos()
    {
        return await _relatorioDomainService.ObterTodos();
    }

    /// <summary>
    /// Método privado para validação.
    /// </summary>
    private async Task<(bool valido, string mensagemErro)> ValidarRelatorioRequest(RelatorioRequest request)
    {
        var relatorio = new Relatorio
        {
            Cidade = request.Cidade,
            SolicitanteId = request.SolicitanteId,
            DataHora = DateTime.Now
        };

        var solicitante = await _solicitanteDomainService.ObterPorId(request.SolicitanteId);

        if (solicitante == null)
            return (false, "Solicitante não encontrado.");

        var validationResult = await _validator.ValidateAsync(relatorio);
        if(!validationResult.IsValid)
        {
            var erros = validationResult.Errors
                .Select(e => e.ErrorMessage)
                .ToList();
            return (false, string.Join(", ", erros));
        }

        return (true, null);
    }

    /// <summary>
    /// Método privado para consultar a API externa e obter o relatório do clima.
    /// </summary>
    private async Task<Relatorio> ConsultarApi(RelatorioRequest request)
    {
        var url = $"https://api.openweathermap.org/data/2.5/weather?q={request.Cidade}&appid=5d35be4587ec4b2078b25a41699b10c7&units=metric&lang=pt_br";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
            throw new Exception("Erro ao consultar a API externa.");

        var content = await response.Content.ReadAsStringAsync();

        var respostaApi = JsonSerializer.Deserialize<RespostaClima>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        if (respostaApi == null)
            throw new Exception("Não foi possível desserializar a resposta da API.");

        var relatorio = new Relatorio
        {
            Cidade = respostaApi.Name,
            Pais = respostaApi.Sys?.Country,
            Temperatura = respostaApi.Main?.Temp ?? 0,
            Condicao = respostaApi.Weather?.FirstOrDefault()?.Description,
            VelocidadeVento = respostaApi.Wind?.Speed ?? 0,
            SolicitanteId = request.SolicitanteId,
            DataHora = DateTime.UtcNow
        };

        return relatorio;
    }
}

#region Classes de apoio na resposta da API

public class WeatherInfo
{
    public string Description { get; set; }
}

public class MainInfo
{
    public decimal Temp { get; set; }
}

public class WindInfo
{
    public decimal Speed { get; set; }
}

public class SysInfo
{
    public string Country { get; set; }
}

public class RespostaClima
{
    public string Name { get; set; }// Cidade
    public SysInfo Sys { get; set; }// País
    public MainInfo Main { get; set; }// Temperatura
    public List<WeatherInfo> Weather { get; set; }// Condição
    public WindInfo Wind { get; set; }// Velocidade do vento
}

#endregion