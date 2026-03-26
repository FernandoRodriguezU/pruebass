using Business.DTOs.Requests;
using Business.UseCases.Evaluaciones;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EvaluacionesController(
    CreateEvaluacionUseCase createEvaluacionUseCase,
    ListEvaluacionesUseCase listEvaluacionesUseCase,
    GetEvaluacionByIdUseCase getEvaluacionByIdUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int? cursoId = null, [FromQuery] int? moduloId = null)
    {
        var result = await listEvaluacionesUseCase.ExecuteAsync(cursoId, moduloId);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var result = await getEvaluacionByIdUseCase.ExecuteAsync(id);
        if (result.IsSuccess) return Ok(result.Value);
        return NotFound(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateEvaluacionDto dto)
    {
        var result = await createEvaluacionUseCase.ExecuteAsync(dto);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }
}