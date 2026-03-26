namespace Business.DTOs.Responses;

public class OpcionPreguntaDto
{
    public int Id { get; set; }
    public int PreguntaEvaluacionId { get; set; }
    public string Texto { get; set; } = null!;
    public int Orden { get; set; }
}