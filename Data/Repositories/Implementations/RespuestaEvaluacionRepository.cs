using Data.Context;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class RespuestaEvaluacionRepository(AppDbContext context) : IRespuestaEvaluacionRepository
{
    public async Task<RespuestaEvaluacion> UpsertAsync(RespuestaEvaluacion respuesta)
    {
        var existente = await context.RespuestasEvaluacion.FirstOrDefaultAsync(r =>
            r.IntentoEvaluacionId == respuesta.IntentoEvaluacionId &&
            r.PreguntaEvaluacionId == respuesta.PreguntaEvaluacionId &&
            r.EntityStatus == 1);

        if (existente is null)
        {
            context.RespuestasEvaluacion.Add(respuesta);
            await context.SaveChangesAsync();
            return respuesta;
        }

        existente.OpcionPreguntaId = respuesta.OpcionPreguntaId;
        existente.RespuestaTexto = respuesta.RespuestaTexto;
        existente.UpdatedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return existente;
    }

    public async Task<IEnumerable<RespuestaEvaluacion>> GetByIntentoAsync(int intentoId)
    {
        return await context.RespuestasEvaluacion
            .AsNoTracking()
            .Where(r => r.IntentoEvaluacionId == intentoId && r.EntityStatus == 1)
            .ToListAsync();
    }
}