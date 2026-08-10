using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PopLume.Application.Dtos;
using PopLume.Application.Services;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using Xunit;

namespace PopLume.Tests.Unitarios.Services;

public class ProdutoServiceTests
{
    private readonly Mock<IProdutoRepository> repository = new();
    private readonly Mock<IUnitOfWork> unitOfWork = new();
    private readonly ProdutoService service;

    public ProdutoServiceTests()
    {
        repository.SetupGet(x => x.UnitOfWork).Returns(unitOfWork.Object);
        repository.Setup(x => x.ObterTodasComposicoesAsync(It.IsAny<CancellationToken>())).ReturnsAsync([]);
        repository.Setup(x => x.VariacaoPertenceAoProdutoAsync(It.IsAny<Guid>(), It.IsAny<Guid>(), It.IsAny<CancellationToken>())).ReturnsAsync(true);
        service = new ProdutoService(repository.Object, Mock.Of<ILogger<ProdutoService>>());
    }

    [Fact]
    public async Task AdicionarAsync_DeveCriarUmProdutoComVariacoes()
    {
        Produto? salvo = null;
        repository.Setup(x => x.Adicionar(It.IsAny<Produto>())).Callback<Produto>(x => salvo = x);
        var dto = new CreateProdutoDto
        {
            Nome = "Vaso",
            Variacoes =
            [
                CriarVariacao("Preto"),
                CriarVariacao("Azul"),
                CriarVariacao("Verde")
            ]
        };

        var resultado = await service.AdicionarAsync(dto);

        resultado.Ok.Should().BeTrue();
        salvo.Should().NotBeNull();
        salvo!.Variacoes.Should().HaveCount(3);
    }

    [Fact]
    public async Task AtualizarAsync_DeveRejeitarComposicaoDiretaComOProprioProduto()
    {
        var id = Guid.NewGuid();
        repository.Setup(x => x.ObterProdutosPorIdAsync(id, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Produto { IdProduto = id, Nome = "Kit" });
        var dto = new UpdateProdutoDto
        {
            IdProduto = id,
            Nome = "Kit",
            Componentes = [CriarComponente(id)]
        };

        var resultado = await service.AtualizarAsync(dto);

        resultado.Ok.Should().BeFalse();
        repository.Verify(x => x.Atualizar(It.IsAny<Produto>()), Times.Never);
    }

    [Fact]
    public async Task AtualizarAsync_DeveRejeitarCicloIndireto()
    {
        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        repository.Setup(x => x.ObterProdutosPorIdAsync(a, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Produto { IdProduto = a, Nome = "A" });
        repository.Setup(x => x.ObterTodasComposicoesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([
                new ProdutoComposicao { IdProdutoPai = b, IdProdutoFilho = c, Quantidade = 1 },
                new ProdutoComposicao { IdProdutoPai = c, IdProdutoFilho = a, Quantidade = 1 }
            ]);
        var dto = new UpdateProdutoDto
        {
            IdProduto = a,
            Nome = "A",
            Componentes = [CriarComponente(b)]
        };

        var resultado = await service.AtualizarAsync(dto);

        resultado.Ok.Should().BeFalse();
        repository.Verify(x => x.Atualizar(It.IsAny<Produto>()), Times.Never);
    }

    [Fact]
    public async Task AtualizarAsync_DeveAceitarKitSemCiclo()
    {
        var kit = Guid.NewGuid();
        repository.Setup(x => x.ObterProdutosPorIdAsync(kit, It.IsAny<CancellationToken>()))
            .ReturnsAsync(new Produto { IdProduto = kit, Nome = "Kit" });
        var dto = new UpdateProdutoDto
        {
            IdProduto = kit,
            Nome = "Kit Dia dos Pais",
            Componentes = [CriarComponente(Guid.NewGuid()), CriarComponente(Guid.NewGuid()), CriarComponente(Guid.NewGuid())]
        };

        var resultado = await service.AtualizarAsync(dto);

        resultado.Ok.Should().BeTrue();
        repository.Verify(x => x.Atualizar(It.Is<Produto>(p => p.ComposicoesPai.Count == 3)), Times.Once);
    }

    private static ProdutoVariacaoInputDto CriarVariacao(string nome) => new()
    {
        Nome = nome,
        Filamentos = [new ProdutoVariacaoFilamentoInputDto
        {
            IdFilamento = Guid.NewGuid(),
            QuantidadeGramas = 100
        }]
    };

    private static ProdutoComponenteDto CriarComponente(Guid idProduto) => new()
    {
        IdProdutoFilho = idProduto,
        IdProdutoVariacaoFilho = Guid.NewGuid(),
        Quantidade = 1
    };
}
