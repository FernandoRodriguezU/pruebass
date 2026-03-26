using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Results;
using Data.Entities;
using Data.Enums;
using Data.Repositories.Interfaces;
using FluentValidation;

namespace Business.UseCases.Opciones;

public class CreateOpcionPreguntaUseCase(
    IPreguntaEvaluacionRepository preguntaRepository,
    IOpcionPreguntaRepository repository,
    IMapper mapper,
    IValidator<CreateOpcionPreguntaDto> validator)
{
    public async Task<Result<OpcionPreguntaDto>> ExecuteAsync(CreateOpcionPreguntaDto dto)
    {
        var validation = await validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return Result<OpcionPreguntaDto>.Failure(validation.Errors.Select(e => e.ErrorMessage));

        var pregunta = await preguntaRepository.GetByIdAsync(dto.PreguntaEvaluacionId);
        if (pregunta is null)
            return Result<OpcionPreguntaDto>.Failure(["La pregunta no existe."]);

        if (pregunta.Tipo == PreguntaTipo.Abierta)
            return Result<OpcionPreguntaDto>.Failure(["Una pregunta Abierta no debe tener opciones."]);

        var opcion = mapper.Map<OpcionPregunta>(dto);
        var created = await repository.CreateAsync(opcion);

        return Result<OpcionPreguntaDto>.Success(mapper.Map<OpcionPreguntaDto>(created));
    }
}