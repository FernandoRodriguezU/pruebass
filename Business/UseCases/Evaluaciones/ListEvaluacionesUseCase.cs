using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Evaluaciones;

public class ListEvaluacionesUseCase(IEvaluacionRepository repository, IMapper mapper)
{
    public async Task<Result<IEnumerable<EvaluacionDto>>> ExecuteAsync(int? cursoId = null, int? moduloId = null)
    {
        var evaluaciones = await repository.GetAllAsync(cursoId, moduloId);
        return Result<IEnumerable<EvaluacionDto>>.Success(mapper.Map<IEnumerable<EvaluacionDto>>(evaluaciones));
    }
}