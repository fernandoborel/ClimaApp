using ClimaApp.Domain.Entities;
using FluentValidation;

namespace ClimaApp.Domain.Validations;

/// <summary>
/// Classe para validação de relatórios.
/// </summary>
public class RelatorioValidation : AbstractValidator<Relatorio>
{
    public RelatorioValidation()
    {
        RuleFor(r => r.Cidade)
            .NotNull().WithMessage("Cidade não pode ser vazia!");

        RuleFor(r => r.SolicitanteId)
            .NotNull().WithMessage("Solicitante não pode ser vazio!")
            .GreaterThan(0).WithMessage("Solicitante deve ser um ID válido!");
    }
}