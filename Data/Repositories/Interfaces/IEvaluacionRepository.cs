using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IEvaluacionRepository
{
    Task<Evaluacion> CreateAsync(Evaluacion evaluacion);
    Task<IEnumerable<Evaluacion>> GetAllAsync(int? cursoId = null, int? moduloId = null);
    Task<Evaluacion?> GetByIdAsync(int id);
    Task UpdateAsync(Evaluacion evaluacion);
    Task DeleteAsync(int id);
}