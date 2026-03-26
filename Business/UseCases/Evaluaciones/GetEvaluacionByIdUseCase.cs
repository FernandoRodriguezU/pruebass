using AutoMapper;
using Business.DTOs.Responses;
using Business.Results;
using Data.Repositories.Interfaces;

namespace Business.UseCases.Evaluaciones;

public class GetEvaluacionByIdUseCase(IEvaluacionRepository repository, IMapper mapper)
{
    public async Task<Result<EvaluacionDetalleDto>> ExecuteAsync(int id)
    {
        var evaluacion = await repository.GetByIdAsync(id);
        if (evaluacion is null)
            return Result<EvaluacionDetalleDto>.Failure(["Evaluación no encontrada."]);

        return Result<EvaluacionDetalleDto>.Success(mapper.Map<EvaluacionDetalleDto>(evaluacion));
    }
}