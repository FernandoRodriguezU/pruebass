using Data.Enums;

namespace Business.DTOs.Requests;

public class CreatePreguntaEvaluacionDto
{
    public int EvaluacionId { get; set; }
    public string Enunciado { get; set; } = null!;
    public PreguntaTipo Tipo { get; set; }
    public int Puntaje { get; set; }
    public int Orden { get; set; }
}