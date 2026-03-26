using Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.Context;

public class AppDbContext(DbContextOptions<AppDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Person> People { get; set; }
    public DbSet<BancoPregunta> BancoPreguntas { get; set; }
    public DbSet<Evaluacion> Evaluaciones { get; set; }
    public DbSet<PreguntaEvaluacion> PreguntasEvaluacion { get; set; }
    public DbSet<OpcionPregunta> OpcionesPregunta { get; set; }
    public DbSet<IntentoEvaluacion> IntentosEvaluacion { get; set; }
    public DbSet<RespuestaEvaluacion> RespuestasEvaluacion { get; set; }

    // Auth Entities
    public DbSet<RefreshToken> RefreshTokens { get; set; }

    // LMS Entities
    public DbSet<Docente> Docentes { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Curso> Cursos { get; set; }
    public DbSet<Modulo> Modulos { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<RespuestaEvaluacion>()
            .HasOne(r => r.IntentoEvaluacion)
            .WithMany(i => i.Respuestas)
            .HasForeignKey(r => r.IntentoEvaluacionId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<RespuestaEvaluacion>()
            .HasOne(r => r.PreguntaEvaluacion)
            .WithMany()
            .HasForeignKey(r => r.PreguntaEvaluacionId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
