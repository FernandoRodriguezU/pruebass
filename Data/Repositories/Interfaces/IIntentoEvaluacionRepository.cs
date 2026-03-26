using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IIntentoEvaluacionRepository
{
    Task<IntentoEvaluacion> CreateAsync(IntentoEvaluacion intento);
    Task<IntentoEvaluacion?> GetByIdAsync(int id);
    Task<IntentoEvaluacion?> GetDetalleByIdAsync(int id);
    Task<IntentoEvaluacion?> GetEnProcesoAsync(int evaluacionId, string estudianteUserId);
    Task UpdateAsync(IntentoEvaluacion intento);
}