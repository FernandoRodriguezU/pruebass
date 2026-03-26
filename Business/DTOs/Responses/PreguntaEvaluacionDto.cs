using Data.Enums;

namespace Business.DTOs.Responses;

public class PreguntaEvaluacionDto
{
    public int Id { get; set; }
    public int EvaluacionId { get; set; }
    public string Enunciado { get; set; } = null!;
    public PreguntaTipo Tipo { get; set; }
    public int Puntaje { get; set; }
    public int Orden { get; set; }

    public List<OpcionPreguntaDto> Opciones { get; set; } = [];
}