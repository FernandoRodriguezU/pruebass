namespace Business.DTOs.Responses;

public class EvaluacionDetalleDto : EvaluacionDto
{
    public string? Descripcion { get; set; }
    public DateTime? DisponibleDesde { get; set; }
    public DateTime? DisponibleHasta { get; set; }

    public List<PreguntaEvaluacionDto> Preguntas { get; set; } = [];
}