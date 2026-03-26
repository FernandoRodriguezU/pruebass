using Business.DTOs.Requests;
using FluentValidation;

namespace Business.Validators;

public class CreateOpcionPreguntaDtoValidator : AbstractValidator<CreateOpcionPreguntaDto>
{
    public CreateOpcionPreguntaDtoValidator()
    {
        RuleFor(x => x.PreguntaEvaluacionId).GreaterThan(0);
        RuleFor(x => x.Texto).NotEmpty().MaximumLength(250);
        RuleFor(x => x.Orden).GreaterThanOrEqualTo(0);
    }
}