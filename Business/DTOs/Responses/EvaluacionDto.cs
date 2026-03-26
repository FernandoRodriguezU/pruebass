namespace Business.DTOs.Responses;

public class EvaluacionDto
{
    public int Id { get; set; }
    public int CursoId { get; set; }
    public int? ModuloId { get; set; }
    public string Titulo { get; set; } = null!;
    public bool Publicado { get; set; }
    public int DuracionMin { get; set; }
}