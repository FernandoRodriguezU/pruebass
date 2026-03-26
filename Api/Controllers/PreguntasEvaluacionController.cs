using Business.DTOs.Requests;
using Business.UseCases.Preguntas;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PreguntasEvaluacionController(
    CreatePreguntaEvaluacionUseCase createPreguntaUseCase,
    ListPreguntasByEvaluacionUseCase listPreguntasUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int evaluacionId)
    {
        var result = await listPreguntasUseCase.ExecuteAsync(evaluacionId);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreatePreguntaEvaluacionDto dto)
    {
        var result = await createPreguntaUseCase.ExecuteAsync(dto);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }
}