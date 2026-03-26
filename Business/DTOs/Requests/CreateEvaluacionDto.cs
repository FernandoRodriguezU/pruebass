namespace Business.DTOs.Requests;

public class CreateEvaluacionDto
{
    public int CursoId { get; set; }
    public int? ModuloId { get; set; }
    public int? DocenteId { get; set; }

    public string Titulo { get; set; } = null!;
    public string? Descripcion { get; set; }

    public int DuracionMin { get; set; }
    public bool Publicado { get; set; }

    public DateTime? DisponibleDesde { get; set; }
    public DateTime? DisponibleHasta { get; set; }
}