using Data.Context;
using Data.Entities;
using Data.Enums;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class IntentoEvaluacionRepository(AppDbContext context) : IIntentoEvaluacionRepository
{
    public async Task<IntentoEvaluacion> CreateAsync(IntentoEvaluacion intento)
    {
        context.IntentosEvaluacion.Add(intento);
        await context.SaveChangesAsync();
        return intento;
    }

    public async Task<IntentoEvaluacion?> GetByIdAsync(int id)
    {
        return await context.IntentosEvaluacion
            .Include(i => i.Respuestas.Where(r => r.EntityStatus == 1))
            .FirstOrDefaultAsync(i => i.Id == id && i.EntityStatus == 1);
    }

    public async Task<IntentoEvaluacion?> GetDetalleByIdAsync(int id)
    {
        return await context.IntentosEvaluacion
            .Include(i => i.Evaluacion!)
                .ThenInclude(e => e.Preguntas.Where(p => p.EntityStatus == 1))
                    .ThenInclude(p => p.Opciones.Where(o => o.EntityStatus == 1))
            .Include(i => i.Respuestas.Where(r => r.EntityStatus == 1))
            .FirstOrDefaultAsync(i => i.Id == id && i.EntityStatus == 1);
    }

    public async Task<IntentoEvaluacion?> GetEnProcesoAsync(int evaluacionId, string estudianteUserId)
    {
        return await context.IntentosEvaluacion
            .FirstOrDefaultAsync(i =>
                i.EvaluacionId == evaluacionId &&
                i.EstudianteUserId == estudianteUserId &&
                i.Estado == IntentoEstado.EnProceso &&
                i.EntityStatus == 1);
    }

    public async Task UpdateAsync(IntentoEvaluacion intento)
    {
        intento.UpdatedAt = DateTime.UtcNow;
        context.IntentosEvaluacion.Update(intento);
        await context.SaveChangesAsync();
    }
}