using ClimaApp.Domain.Entities;
using FluentValidation;

namespace ClimaApp.Domain.Validations;

/// <summary>
/// Classe para validação de solicitantes.
/// </summary>
public class SolicitanteValidation : AbstractValidator<Solicitante>
{
    public SolicitanteValidation()
    {
        RuleFor(s => s.Nome)
            .NotNull().WithMessage("Nome não pode ser vazio!");
    }
}