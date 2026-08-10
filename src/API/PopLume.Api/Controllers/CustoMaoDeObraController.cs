using Microsoft.AspNetCore.Mvc;
using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;

namespace PopLume.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustoMaoDeObraController(ICustoMaoDeObraService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken) => Responder(await service.ObterTodosAsync(cancellationToken));

    [HttpGet("vigente")]
    public async Task<IActionResult> ObterVigente(CancellationToken cancellationToken) => Responder(await service.ObterVigenteAsync(cancellationToken));

    [HttpPost]
    public async Task<IActionResult> Adicionar(CreateCustoMaoDeObraDto dto, CancellationToken cancellationToken) =>
        Responder(await service.AdicionarAsync(dto, cancellationToken));
}
