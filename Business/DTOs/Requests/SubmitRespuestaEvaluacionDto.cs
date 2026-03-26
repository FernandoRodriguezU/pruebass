namespace Business.DTOs.Requests;

public class SubmitRespuestaEvaluacionDto
{
    public int PreguntaEvaluacionId { get; set; }
    public int? OpcionPreguntaId { get; set; }
    public string? RespuestaTexto { get; set; }
}