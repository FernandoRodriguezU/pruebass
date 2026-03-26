using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Results;
using Data.Entities;
using Data.Repositories.Interfaces;
using FluentValidation;

namespace Business.UseCases.Preguntas;

public class CreatePreguntaEvaluacionUseCase(
    IEvaluacionRepository evaluacionRepository,
    IPreguntaEvaluacionRepository repository,
    IMapper mapper,
    IValidator<CreatePreguntaEvaluacionDto> validator)
{
    public async Task<Result<PreguntaEvaluacionDto>> ExecuteAsync(CreatePreguntaEvaluacionDto dto)
    {
        var validation = await validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return Result<PreguntaEvaluacionDto>.Failure(validation.Errors.Select(e => e.ErrorMessage));

        var evaluacion = await evaluacionRepository.GetByIdAsync(dto.EvaluacionId);
        if (evaluacion is null)
            return Result<PreguntaEvaluacionDto>.Failure(["La evaluación no existe."]);

        var pregunta = mapper.Map<PreguntaEvaluacion>(dto);
        var created = await repository.CreateAsync(pregunta);

        return Result<PreguntaEvaluacionDto>.Success(mapper.Map<PreguntaEvaluacionDto>(created));
    }
}