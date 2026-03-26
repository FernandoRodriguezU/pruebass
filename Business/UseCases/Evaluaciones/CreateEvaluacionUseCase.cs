using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Results;
using Data.Entities;
using Data.Repositories.Interfaces;
using FluentValidation;

namespace Business.UseCases.Evaluaciones;

public class CreateEvaluacionUseCase(
    IEvaluacionRepository repository,
    IMapper mapper,
    IValidator<CreateEvaluacionDto> validator)
{
    public async Task<Result<EvaluacionDto>> ExecuteAsync(CreateEvaluacionDto dto)
    {
        var validation = await validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return Result<EvaluacionDto>.Failure(validation.Errors.Select(e => e.ErrorMessage));

        var evaluacion = mapper.Map<Evaluacion>(dto);

        var created = await repository.CreateAsync(evaluacion);
        return Result<EvaluacionDto>.Success(mapper.Map<EvaluacionDto>(created));
    }
}