using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class Evaluacion
{
    public int Id { get; set; }

    [Required]
    public int CursoId { get; set; }

    public int? ModuloId { get; set; }

    public int? DocenteId { get; set; }

    [Required, MaxLength(150)]
    public string Titulo { get; set; } = null!;

    public string? Descripcion { get; set; }

    public int DuracionMin { get; set; } = 0;

    public DateTime? DisponibleDesde { get; set; }
    public DateTime? DisponibleHasta { get; set; }

    public bool Publicado { get; set; } = false;

    public short EntityStatus { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public Curso? Curso { get; set; }
    public Modulo? Modulo { get; set; }
    public Docente? Docente { get; set; }

    public ICollection<PreguntaEvaluacion> Preguntas { get; set; } = new List<PreguntaEvaluacion>();
    public ICollection<IntentoEvaluacion> Intentos { get; set; } = new List<IntentoEvaluacion>();
}