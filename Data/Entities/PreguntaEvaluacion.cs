using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Data.Enums;

namespace Data.Entities;

public class PreguntaEvaluacion
{
    public int Id { get; set; }

    [Required]
    public int EvaluacionId { get; set; }

    [Required, MaxLength(500)]
    public string Enunciado { get; set; } = null!;

    public PreguntaTipo Tipo { get; set; } = PreguntaTipo.OpcionUnica;

    public int Puntaje { get; set; } = 1;

    public int Orden { get; set; } = 0;

    public short EntityStatus { get; set; } = 1;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? DeletedAt { get; set; }

    public Evaluacion? Evaluacion { get; set; }

    public ICollection<OpcionPregunta> Opciones { get; set; } = new List<OpcionPregunta>();
}
