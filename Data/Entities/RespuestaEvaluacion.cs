using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class RespuestaEvaluacion
{
    public int Id { get; set; }

    [Required]
    public int IntentoEvaluacionId { get; set; }

    [Required]
    public int PreguntaEvaluacionId { get; set; }

    public int? OpcionPreguntaId { get; set; }

    [MaxLength(2000)]
    public string? RespuestaTexto { get; set; }

    public bool? EsCorrecta { get; set; }          // Sprint 2
    public decimal? PuntajeObtenido { get; set; }  // Sprint 2

    public short EntityStatus { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public IntentoEvaluacion? IntentoEvaluacion { get; set; }
    public PreguntaEvaluacion? PreguntaEvaluacion { get; set; }
    public OpcionPregunta? OpcionPregunta { get; set; }
}