using Business.DTOs.Requests;
using FluentValidation;

namespace Business.Validators;

public class CreateEvaluacionDtoValidator : AbstractValidator<CreateEvaluacionDto>
{
    public CreateEvaluacionDtoValidator()
    {
        RuleFor(x => x.CursoId).GreaterThan(0);
        RuleFor(x => x.Titulo).NotEmpty().MaximumLength(150);
        RuleFor(x => x.DuracionMin).GreaterThanOrEqualTo(0);

        When(x => x.ModuloId.HasValue, () =>
        {
            RuleFor(x => x.ModuloId!.Value).GreaterThan(0);
        });

        When(x => x.DisponibleDesde.HasValue && x.DisponibleHasta.HasValue, () =>
        {
            RuleFor(x => x.DisponibleHasta)
                .GreaterThan(x => x.DisponibleDesde)
                .WithMessage("DisponibleHasta debe ser mayor que DisponibleDesde.");
        });
    }
}