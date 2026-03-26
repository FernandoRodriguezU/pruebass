using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Opciones;

public class ListOpcionesByPreguntaUseCase(IOpcionPreguntaRepository repository, IMapper mapper)
{
    public async Task<Result<IEnumerable<OpcionPreguntaDto>>> ExecuteAsync(int preguntaEvaluacionId)
    {
        var opciones = await repository.GetByPreguntaIdAsync(preguntaEvaluacionId);
        return Result<IEnumerable<OpcionPreguntaDto>>.Success(mapper.Map<IEnumerable<OpcionPreguntaDto>>(opciones));
    }
}