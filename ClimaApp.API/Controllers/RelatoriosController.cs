using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ClimaApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RelatoriosController : ControllerBase
{
    private readonly IRelatorioAppService _relatorioAppService;

    public RelatoriosController(IRelatorioAppService relatorioAppService)
    {
        _relatorioAppService = relatorioAppService;
    }

    /// <summary>
    /// Gera um novo relatório de temperatura consultando a API externa.
    /// </summary>
    /// <param name="request">
    /// Objeto com os parâmetros de consulta ao InfoDengue:
    /// 
    /// - <b>Cidade</b>:
    ///   - Exemplo RJ (Rio de Janeiro)
    ///   - Exemplo SP (São Paulo)
    /// 
    /// - <b>Pais</b>: País de origem da cidade que esta sendo consultada.
    /// 
    /// - <b>Temperatura</b>: Temperatura da cidade que esta sendo consultada.
    /// 
    /// - <b>Condicao</b>: Condição atual da cidade. Exemplo: Nublado, Ensolarado, ...
    /// 
    /// - <b>VelocidadeVento</b>: Velocidade do vento na cidade. Exemplo: 3.14Km/h.
    /// </param>
    /// <returns>
    /// Retorna HTTP 200 com os detalhes do relatório gerado e salvo no sistema.
    /// Em caso de erro de validação, retorna HTTP 400 com a lista de erros.
    /// Em caso de erro ao consultar a API externa, também retorna HTTP 400.
    /// Em caso de falha interna, retorna HTTP 500.
    /// </returns>
    /// <response code="200">Relatório gerado e salvo com sucesso.</response>
    /// <response code="400">Erro de validação nos parâmetros ou falha ao consultar a API externa.</response>
    /// <response code="500">Erro interno ao processar a requisição.</response>
    [HttpPost("adicionar")]
    [ProducesResponseType(typeof(RelatorioResponse), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> Adicionar([FromBody] RelatorioRequest request)
    {
        try
        {
            var relatorioResponse = await _relatorioAppService.Adicionar(request);
            return Ok(relatorioResponse);
        }
        catch (ValidationException ex)
        {
            var erros = ex.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { Errors = erros });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }

    /// <summary>
    /// Obtém todos os relatórios de temperatura gerados e salvos no sistema.
    /// </summary>
    /// <returns></returns>
    [HttpGet("obter-todos")]
    [ProducesResponseType(typeof(List<RelatorioResponse>), 200)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    public async Task<IActionResult> ObterTodos()
    {
        try
        {
            var relatorios = await _relatorioAppService.ObterTodos();
            return Ok(relatorios);
        }
        catch (Exception ex)
        {
            return BadRequest(new { Error = ex.Message });
        }
    }
}
