using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IOpcionPreguntaRepository
{
    Task<OpcionPregunta> CreateAsync(OpcionPregunta opcion);
    Task<IEnumerable<OpcionPregunta>> GetByPreguntaIdAsync(int preguntaEvaluacionId);
    Task<OpcionPregunta?> GetByIdAsync(int id);
    Task UpdateAsync(OpcionPregunta opcion);
    Task DeleteAsync(int id);
}