using Data.Context;
using Data.Entities;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories.Implementations;

public class EvaluacionRepository(AppDbContext context) : IEvaluacionRepository
{
    public async Task<Evaluacion> CreateAsync(Evaluacion evaluacion)
    {
        context.Evaluaciones.Add(evaluacion);
        await context.SaveChangesAsync();
        return evaluacion;
    }

    public async Task<IEnumerable<Evaluacion>> GetAllAsync(int? cursoId = null, int? moduloId = null)
    {
        var query = context.Evaluaciones
            .AsNoTracking()
            .Where(e => e.EntityStatus == 1);

        if (cursoId.HasValue) query = query.Where(e => e.CursoId == cursoId.Value);
        if (moduloId.HasValue) query = query.Where(e => e.ModuloId == moduloId.Value);

        return await query
            .Include(e => e.Curso)
            .Include(e => e.Modulo)
            .ToListAsync();
    }

    public async Task<Evaluacion?> GetByIdAsync(int id)
    {
        return await context.Evaluaciones
            .Include(e => e.Curso)
            .Include(e => e.Modulo)
            .Include(e => e.Preguntas.Where(p => p.EntityStatus == 1))
                .ThenInclude(p => p.Opciones.Where(o => o.EntityStatus == 1))
            .FirstOrDefaultAsync(e => e.Id == id && e.EntityStatus == 1);
    }

    public async Task UpdateAsync(Evaluacion evaluacion)
    {
        evaluacion.UpdatedAt = DateTime.UtcNow;
        context.Evaluaciones.Update(evaluacion);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var evaluacion = await context.Evaluaciones.FirstOrDefaultAsync(e => e.Id == id && e.EntityStatus == 1);
        if (evaluacion is null) return;

        evaluacion.EntityStatus = 0;
        evaluacion.DeletedAt = DateTime.UtcNow;

        await context.SaveChangesAsync();
    }
}