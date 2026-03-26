using Business.DTOs.Requests;
using FluentValidation;

namespace Business.Validators;

public class StartIntentoEvaluacionDtoValidator : AbstractValidator<StartIntentoEvaluacionDto>
{
    public StartIntentoEvaluacionDtoValidator()
    {
        RuleFor(x => x.EvaluacionId).GreaterThan(0);
        RuleFor(x => x.EstudianteUserId).NotEmpty();
    }
}