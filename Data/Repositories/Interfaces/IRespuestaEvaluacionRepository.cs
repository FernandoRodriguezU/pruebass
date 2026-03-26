using Data.Entities;

namespace Data.Repositories.Interfaces;

public interface IRespuestaEvaluacionRepository
{
    Task<RespuestaEvaluacion> UpsertAsync(RespuestaEvaluacion respuesta);
    Task<IEnumerable<RespuestaEvaluacion>> GetByIntentoAsync(int intentoId);
}