using ClimaApp.Application.Dtos.Request;
using ClimaApp.Application.Dtos.Response;
using ClimaApp.Application.Interfaces;
using ClimaApp.Domain.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace ClimaApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SolicitantesController : ControllerBase
{
    private readonly ISolicitanteAppService _solicitanteAppService;
    private readonly IValidator<Solicitante> _validator;

    public SolicitantesController(ISolicitanteAppService solicitanteAppService, IValidator<Solicitante> validator)
    {
        _solicitanteAppService = solicitanteAppService;
        _validator = validator;
    }

    /// <summary>
    /// Adiciona um novo solicitante ao sistema.
    /// </summary>
    /// <param name="request">Objeto contendo os dados do solicitante (ex: Nome, CPF, etc).</param>
    /// <returns>
    /// Retorna HTTP 201 com os detalhes do solicitante criado.  
    /// Em caso de erro de validação, retorna HTTP 400 com a lista de erros.  
    /// Em caso de erro interno, retorna HTTP 500.
    /// </returns>
    /// <response code="201">Solicitante criado com sucesso.</response>
    /// <response code="400">Erro de validação nos dados enviados.</response>
    /// <response code="500">Erro interno ao processar a requisição.</response>
    [ProducesResponseType(typeof(SolicitanteResponse), 201)]
    [ProducesResponseType(typeof(object), 400)]
    [ProducesResponseType(typeof(string), 500)]
    [HttpPost("adicionar")]
    public async Task<IActionResult> Adicionar ([FromBody] SolicitanteRequest request)
    {
        #region Validações

        var solicitante = new Solicitante
        {
            Nome = request.Nome
        };

        // Validação com FluentValidation
        var validationResult = await _validator.ValidateAsync(solicitante);

        if (!validationResult.IsValid)
        {
            var erros = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            return BadRequest(new { Errors = erros });
        }

        #endregion

        try
        {
            var response = await _solicitanteAppService.Adicionar(request);
            if (response == null)
            {
                return BadRequest("Erro ao adicionar solicitante.");
            }
            return Ok(response);

        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro interno: {ex.Message}");
        }
    }

}