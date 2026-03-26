using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IPreguntaEvaluacionRepository
{
    Task<PreguntaEvaluacion> CreateAsync(PreguntaEvaluacion pregunta);
    Task<IEnumerable<PreguntaEvaluacion>> GetByEvaluacionIdAsync(int evaluacionId);
    Task<PreguntaEvaluacion?> GetByIdAsync(int id);
    Task UpdateAsync(PreguntaEvaluacion pregunta);
    Task DeleteAsync(int id);
}