using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Enums;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Intentos;

public class EnviarIntentoUseCase(IIntentoEvaluacionRepository intentoRepository, IMapper mapper)
{
    public async Task<Result<IntentoEvaluacionDto>> ExecuteAsync(int intentoId)
    {
        var intento = await intentoRepository.GetDetalleByIdAsync(intentoId);
        if (intento is null)
            return Result<IntentoEvaluacionDto>.Failure(["Intento no encontrado."]);

        if (intento.Estado != IntentoEstado.EnProceso)
            return Result<IntentoEvaluacionDto>.Failure(["El intento no está en estado EnProceso."]);

        var preguntasActivas = intento.Evaluacion?.Preguntas.Where(p => p.EntityStatus == 1).ToList() ?? [];
        var respuestasActivas = intento.Respuestas.Where(r => r.EntityStatus == 1).ToList();

        // Regla simple Sprint 1: debe responder todas las preguntas activas
        var respondidas = respuestasActivas.Select(r => r.PreguntaEvaluacionId).Distinct().ToHashSet();
        var faltantes = preguntasActivas.Where(p => !respondidas.Contains(p.Id)).ToList();

        if (faltantes.Count > 0)
            return Result<IntentoEvaluacionDto>.Failure([$"Faltan respuestas para {faltantes.Count} pregunta(s)."]);

        intento.Estado = IntentoEstado.Enviado;
        intento.FinishedAt = DateTime.UtcNow;

        await intentoRepository.UpdateAsync(intento);
        return Result<IntentoEvaluacionDto>.Success(mapper.Map<IntentoEvaluacionDto>(intento));
    }
}