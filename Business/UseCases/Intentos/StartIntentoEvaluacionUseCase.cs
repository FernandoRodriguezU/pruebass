using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Results;
using Data.Entities;
using Data.Repositories.Interfaces;
using FluentValidation;

namespace Business.UseCases.Intentos;

public class StartIntentoEvaluacionUseCase(
    IEvaluacionRepository evaluacionRepository,
    IIntentoEvaluacionRepository repository,
    IMapper mapper,
    IValidator<StartIntentoEvaluacionDto> validator)
{
    public async Task<Result<IntentoEvaluacionDto>> ExecuteAsync(StartIntentoEvaluacionDto dto)
    {
        var validation = await validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return Result<IntentoEvaluacionDto>.Failure(validation.Errors.Select(e => e.ErrorMessage));

        var evaluacion = await evaluacionRepository.GetByIdAsync(dto.EvaluacionId);
        if (evaluacion is null)
            return Result<IntentoEvaluacionDto>.Failure(["La evaluación no existe."]);

        var existente = await repository.GetEnProcesoAsync(dto.EvaluacionId, dto.EstudianteUserId);
        if (existente is not null)
            return Result<IntentoEvaluacionDto>.Success(mapper.Map<IntentoEvaluacionDto>(existente));

        var intento = new IntentoEvaluacion
        {
            EvaluacionId = dto.EvaluacionId,
            EstudianteUserId = dto.EstudianteUserId
        };

        var created = await repository.CreateAsync(intento);
        return Result<IntentoEvaluacionDto>.Success(mapper.Map<IntentoEvaluacionDto>(created));
    }
}