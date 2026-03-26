using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Entities;

public class IntentoEvaluacion
{
    public int Id { get; set; }

    [Required]
    public int EvaluacionId { get; set; }

    [Required]
    public string EstudianteUserId { get; set; } = null!;

    public IntentoEstado Estado { get; set; } = IntentoEstado.EnProceso;

    public DateTime StartedAt { get; set; } = DateTime.UtcNow;
    public DateTime? FinishedAt { get; set; }

    public decimal? PuntajeObtenido { get; set; } // Sprint 2
    public decimal? PuntajeTotal { get; set; }    // Sprint 2

    public short EntityStatus { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public Evaluacion? Evaluacion { get; set; }
    public User? Estudiante { get; set; }

    public ICollection<RespuestaEvaluacion> Respuestas { get; set; } = new List<RespuestaEvaluacion>();
}