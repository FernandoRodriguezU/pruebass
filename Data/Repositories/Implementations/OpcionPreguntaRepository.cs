using Data.Context;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class OpcionPreguntaRepository(AppDbContext context) : IOpcionPreguntaRepository
{
    public async Task<OpcionPregunta> CreateAsync(OpcionPregunta opcion)
    {
        context.OpcionesPregunta.Add(opcion);
        await context.SaveChangesAsync();
        return opcion;
    }

    public async Task<IEnumerable<OpcionPregunta>> GetByPreguntaIdAsync(int preguntaEvaluacionId)
    {
        return await context.OpcionesPregunta
            .AsNoTracking()
            .Where(o => o.PreguntaEvaluacionId == preguntaEvaluacionId && o.EntityStatus == 1)
            .OrderBy(o => o.Orden)
            .ToListAsync();
    }

    public async Task<OpcionPregunta?> GetByIdAsync(int id)
    {
        return await context.OpcionesPregunta
            .FirstOrDefaultAsync(o => o.Id == id && o.EntityStatus == 1);
    }

    public async Task UpdateAsync(OpcionPregunta opcion)
    {
        opcion.UpdatedAt = DateTime.UtcNow;
        context.OpcionesPregunta.Update(opcion);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var opcion = await context.OpcionesPregunta.FirstOrDefaultAsync(o => o.Id == id && o.EntityStatus == 1);
        if (opcion is null) return;

        opcion.EntityStatus = 0;
        opcion.DeletedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
    }
}