using Data.Enums;

namespace Business.DTOs.Responses;

public class IntentoEvaluacionDto
{
    public int Id { get; set; }
    public int EvaluacionId { get; set; }
    public string EstudianteUserId { get; set; } = null!;
    public IntentoEstado Estado { get; set; }
    public DateTime StartedAt { get; set; }
    public DateTime? FinishedAt { get; set; }
}