namespace Business.DTOs.Requests;

public class StartIntentoEvaluacionDto
{
    public int EvaluacionId { get; set; }
    public string EstudianteUserId { get; set; } = null!;
}