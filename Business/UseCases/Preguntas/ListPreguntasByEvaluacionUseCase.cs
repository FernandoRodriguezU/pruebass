using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Preguntas;

public class ListPreguntasByEvaluacionUseCase(IPreguntaEvaluacionRepository repository, IMapper mapper)
{
    public async Task<Result<IEnumerable<PreguntaEvaluacionDto>>> ExecuteAsync(int evaluacionId)
    {
        var preguntas = await repository.GetByEvaluacionIdAsync(evaluacionId);
        return Result<IEnumerable<PreguntaEvaluacionDto>>.Success(mapper.Map<IEnumerable<PreguntaEvaluacionDto>>(preguntas));
    }
}