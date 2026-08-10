using Microsoft.AspNetCore.Mvc;
using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;

namespace PopLume.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsumoController(IInsumoService service) : BaseController
{
    [HttpGet]
    public async Task<IActionResult> ObterTodos(CancellationToken cancellationToken) =>
        Responder(await service.ObterTodosAsync(cancellationToken));

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> ObterPorId(Guid id, CancellationToken cancellationToken) =>
        Responder(await service.ObterPorIdAsync(id, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> Adicionar(CreateInsumoDto dto, CancellationToken cancellationToken)
    {
        var resultado = await service.AdicionarAsync(dto, cancellationToken);
        return resultado.Ok ? CreatedAtAction(nameof(ObterPorId), new { id = resultado.Data }, resultado) : BadRequest(resultado);
    }

    [HttpPut]
    public async Task<IActionResult> Atualizar(UpdateInsumoDto dto, CancellationToken cancellationToken) =>
        Responder(await service.AtualizarAsync(dto, cancellationToken));

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Remover(Guid id, CancellationToken cancellationToken) =>
        Responder(await service.RemoverAsync(id, cancellationToken));
}
