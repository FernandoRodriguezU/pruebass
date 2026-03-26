using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Intentos;

public class GetIntentoDetalleUseCase(IIntentoEvaluacionRepository repository, IMapper mapper)
{
    public async Task<Result<object>> ExecuteAsync(int intentoId)
    {
        var intento = await repository.GetDetalleByIdAsync(intentoId);
        if (intento is null)
            return Result<object>.Failure(["Intento no encontrado."]);

        // Retornamos el intento + evaluacion + preguntas + opciones + respuestas
        return Result<object>.Success(new
        {
            intento = mapper.Map<IntentoEvaluacionDto>(intento),
            evaluacion = intento.Evaluacion,
            respuestas = intento.Respuestas
        });
    }
}