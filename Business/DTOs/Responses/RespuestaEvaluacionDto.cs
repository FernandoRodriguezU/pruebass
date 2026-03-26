namespace Business.DTOs.Responses;

public class RespuestaEvaluacionDto
{
    public int Id { get; set; }
    public int IntentoEvaluacionId { get; set; }
    public int PreguntaEvaluacionId { get; set; }
    public int? OpcionPreguntaId { get; set; }
    public string? RespuestaTexto { get; set; }
}