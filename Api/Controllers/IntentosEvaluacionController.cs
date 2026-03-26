using Business.DTOs.Requests;
using Business.UseCases.Intentos;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class IntentosEvaluacionController(
    StartIntentoEvaluacionUseCase startIntentoUseCase,
    GetIntentoDetalleUseCase getIntentoDetalleUseCase,
    SubmitRespuestaUseCase submitRespuestaUseCase,
    EnviarIntentoUseCase enviarIntentoUseCase) : ControllerBase
{
    [HttpPost("start")]
    public async Task<IActionResult> Start([FromBody] StartIntentoEvaluacionDto dto)
    {
        var result = await startIntentoUseCase.ExecuteAsync(dto);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }

    [HttpGet("{intentoId}")]
    public async Task<IActionResult> Get(int intentoId)
    {
        var result = await getIntentoDetalleUseCase.ExecuteAsync(intentoId);
        if (result.IsSuccess) return Ok(result.Value);
        return NotFound(result.Errors);
    }

    [HttpPost("{intentoId}/respuestas")]
    public async Task<IActionResult> Responder(int intentoId, [FromBody] SubmitRespuestaEvaluacionDto dto)
    {
        var result = await submitRespuestaUseCase.ExecuteAsync(intentoId, dto);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }

    [HttpPost("{intentoId}/enviar")]
    public async Task<IActionResult> Enviar(int intentoId)
    {
        var result = await enviarIntentoUseCase.ExecuteAsync(intentoId);
        if (result.IsSuccess) return Ok(result.Value);
        return BadRequest(result.Errors);
    }
}