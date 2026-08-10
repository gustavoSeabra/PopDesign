using Microsoft.AspNetCore.Mvc;
using PopLume.Application.Dtos;
using PopLume.Application.Services.Interfaces;

namespace PopLume.Api.Controllers;

[ApiController]
[Route("api/produto/{idProduto:guid}/precificacoes")]
public class PrecificacaoController(IPrecificacaoService service) : BaseController
{
    [HttpPost("simular")]
    public async Task<IActionResult> Simular(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken) =>
        Responder(await service.SimularAsync(idProduto, dto, cancellationToken));

    [HttpPost]
    public async Task<IActionResult> CalcularESalvar(Guid idProduto, CalcularPrecificacaoDto dto, CancellationToken cancellationToken) =>
        Responder(await service.CalcularESalvarAsync(idProduto, dto, cancellationToken));

    [HttpGet]
    public async Task<IActionResult> ObterHistorico(Guid idProduto, CancellationToken cancellationToken) =>
        Responder(await service.ObterHistoricoAsync(idProduto, cancellationToken));
}
