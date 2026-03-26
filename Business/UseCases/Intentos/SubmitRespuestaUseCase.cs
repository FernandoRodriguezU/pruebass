using AutoMapper;
using Business.DTOs.Requests;
using Business.DTOs.Responses;
using Business.Results;
using Data.Entities;
using Data.Enums;
using Data.Repositories.Interfaces;
using FluentValidation;

namespace Business.UseCases.Intentos;

public class SubmitRespuestaUseCase(
    IIntentoEvaluacionRepository intentoRepository,
    IPreguntaEvaluacionRepository preguntaRepository,
    IOpcionPreguntaRepository opcionRepository,
    IRespuestaEvaluacionRepository respuestaRepository,
    IMapper mapper,
    IValidator<SubmitRespuestaEvaluacionDto> validator)
{
    public async Task<Result<RespuestaEvaluacionDto>> ExecuteAsync(int intentoId, SubmitRespuestaEvaluacionDto dto)
    {
        var validation = await validator.ValidateAsync(dto);
        if (!validation.IsValid)
            return Result<RespuestaEvaluacionDto>.Failure(validation.Errors.Select(e => e.ErrorMessage));

        var intento = await intentoRepository.GetDetalleByIdAsync(intentoId);
        if (intento is null)
            return Result<RespuestaEvaluacionDto>.Failure(["Intento no encontrado."]);

        if (intento.Estado != IntentoEstado.EnProceso)
            return Result<RespuestaEvaluacionDto>.Failure(["El intento no está en estado EnProceso."]);

        var pregunta = await preguntaRepository.GetByIdAsync(dto.PreguntaEvaluacionId);
        if (pregunta is null)
            return Result<RespuestaEvaluacionDto>.Failure(["La pregunta no existe."]);

        if (pregunta.EvaluacionId != intento.EvaluacionId)
            return Result<RespuestaEvaluacionDto>.Failure(["La pregunta no pertenece a la evaluación de este intento."]);

        // Reglas por tipo
        if (pregunta.Tipo == PreguntaTipo.Abierta)
        {
            if (string.IsNullOrWhiteSpace(dto.RespuestaTexto))
                return Result<RespuestaEvaluacionDto>.Failure(["Para pregunta Abierta, RespuestaTexto es requerido."]);
        }
        else
        {
            if (!dto.OpcionPreguntaId.HasValue)
                return Result<RespuestaEvaluacionDto>.Failure(["Para preguntas con opciones, OpcionPreguntaId es requerido."]);

            var opcion = await opcionRepository.GetByIdAsync(dto.OpcionPreguntaId.Value);
            if (opcion is null || opcion.PreguntaEvaluacionId != pregunta.Id)
                return Result<RespuestaEvaluacionDto>.Failure(["La opción no pertenece a la pregunta."]);
        }

        var respuesta = new RespuestaEvaluacion
        {
            IntentoEvaluacionId = intentoId,
            PreguntaEvaluacionId = dto.PreguntaEvaluacionId,
            OpcionPreguntaId = dto.OpcionPreguntaId,
            RespuestaTexto = dto.RespuestaTexto
        };

        var saved = await respuestaRepository.UpsertAsync(respuesta);
        return Result<RespuestaEvaluacionDto>.Success(mapper.Map<RespuestaEvaluacionDto>(saved));
    }
}