using Microsoft.AspNetCore.Mvc;
using PopDesing.Application.Dtos;

namespace PopDesing.Api.Controllers;

public abstract class BaseController : ControllerBase
{
    protected IActionResult Responder<T>(ResultadoDto<T> resultado)
    {
        if (resultado.NotFound)
            return NotFound(resultado);

        if (resultado.Ok)
            return Ok(resultado);

        return BadRequest(resultado);
    }
}
