using Data.Context;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class PreguntaEvaluacionRepository(AppDbContext context) : IPreguntaEvaluacionRepository
{
    public async Task<PreguntaEvaluacion> CreateAsync(PreguntaEvaluacion pregunta)
    {
        context.PreguntasEvaluacion.Add(pregunta);
        await context.SaveChangesAsync();
        return pregunta;
    }

    public async Task<IEnumerable<PreguntaEvaluacion>> GetByEvaluacionIdAsync(int evaluacionId)
    {
        return await context.PreguntasEvaluacion
            .AsNoTracking()
            .Where(p => p.EvaluacionId == evaluacionId && p.EntityStatus == 1)
            .Include(p => p.Opciones.Where(o => o.EntityStatus == 1))
            .OrderBy(p => p.Orden)
            .ToListAsync();
    }

    public async Task<PreguntaEvaluacion?> GetByIdAsync(int id)
    {
        return await context.PreguntasEvaluacion
            .Include(p => p.Opciones.Where(o => o.EntityStatus == 1))
            .FirstOrDefaultAsync(p => p.Id == id && p.EntityStatus == 1);
    }

    public async Task UpdateAsync(PreguntaEvaluacion pregunta)
    {
        pregunta.UpdatedAt = DateTime.UtcNow;
        context.PreguntasEvaluacion.Update(pregunta);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var pregunta = await context.PreguntasEvaluacion.FirstOrDefaultAsync(p => p.Id == id && p.EntityStatus == 1);
        if (pregunta is null) return;

        pregunta.EntityStatus = 0;
        pregunta.DeletedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
    }
}