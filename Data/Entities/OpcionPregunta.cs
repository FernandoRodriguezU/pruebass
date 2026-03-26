using System;
using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class OpcionPregunta
{
    public int Id { get; set; }

    [Required]
    public int PreguntaEvaluacionId { get; set; }

    [Required, MaxLength(250)]
    public string Texto { get; set; } = null!;

    public bool EsCorrecta { get; set; } = false;

    public int Orden { get; set; } = 0;

    public short EntityStatus { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public PreguntaEvaluacion? PreguntaEvaluacion { get; set; }
}