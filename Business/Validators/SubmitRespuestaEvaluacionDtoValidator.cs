using Business.DTOs.Requests;
using FluentValidation;

namespace Business.Validators;

public class SubmitRespuestaEvaluacionDtoValidator : AbstractValidator<SubmitRespuestaEvaluacionDto>
{
    public SubmitRespuestaEvaluacionDtoValidator()
    {
        RuleFor(x => x.PreguntaEvaluacionId).GreaterThan(0);
    }
}