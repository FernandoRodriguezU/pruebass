namespace Business.DTOs.Requests;

public class CreateOpcionPreguntaDto
{
    public int PreguntaEvaluacionId { get; set; }
    public string Texto { get; set; } = null!;
    public bool EsCorrecta { get; set; }
    public int Orden { get; set; }
}