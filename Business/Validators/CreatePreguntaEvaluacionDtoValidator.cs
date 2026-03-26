using Business.DTOs.Requests;
using FluentValidation;

namespace Business.Validators;

public class CreatePreguntaEvaluacionDtoValidator : AbstractValidator<CreatePreguntaEvaluacionDto>
{
    public CreatePreguntaEvaluacionDtoValidator()
    {
        RuleFor(x => x.EvaluacionId).GreaterThan(0);
        RuleFor(x => x.Enunciado).NotEmpty().MaximumLength(500);
        RuleFor(x => x.Puntaje).GreaterThan(0);
        RuleFor(x => x.Orden).GreaterThanOrEqualTo(0);
    }
}