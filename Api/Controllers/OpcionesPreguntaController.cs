using Business.DTOs.Requests;
using Business.UseCases.Opciones;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OpcionesPreguntaController(
    CreateOpcionPreguntaUseCase createOpcionUseCase,
    ListOpcionesByPreguntaUseCase listOpcionesUseCase) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> Get([FromQuery] int preguntaEvaluacionId)
    {
        var result = await listOpcionesUseCase.ExecuteAsync(preguntaEvaluacionId);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateOpcionPreguntaDto dto)
    {
        var result = await createOpcionUseCase.ExecuteAsync(dto);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }
}