using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using PopLume.Application.Dtos;
using PopLume.Application.Services;
using PopLume.Domain.Entities;
using PopLume.Domain.Repositories;
using PopLume.Tests.Mocks.Dtos;
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
        repository.Setup(x => x.ObterTodasComposicoesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync([]);
        service = new ProdutoService(repository.Object, Mock.Of<ILogger<ProdutoService>>());
    }

    [Fact]
    public async Task AdicionarAsync_DeveCriarProdutoSemPrecoDeCustoManual()
    {
        Produto? salvo = null;
        repository.Setup(x => x.Adicionar(It.IsAny<Produto>())).Callback<Produto>(x => salvo = x);
        var dto = new CreateProdutoDto
        {
            Nome = "Chaveiro",
            TempoImpressaoMinutos = 45,
            TempoMaoDeObraMinutos = 10
        };

        _produtoRepositoryMock
            .Setup(repository => repository.ObterProdutosPorNomeAsync(parteNome, It.IsAny<CancellationToken>()))
            .ReturnsAsync(produtos);

        var service = CriarService();

        // Act
        var resultado = await service.ObterPorNomeAsync(parteNome);

        // Assert
        resultado.Ok.Should().BeTrue();
        resultado.Data.Should().NotBeNull();
        resultado.Data.Should().HaveCount(2);
        resultado.Data.Should().OnlyContain(produto => produto.Nome.Contains(parteNome, StringComparison.OrdinalIgnoreCase));

        _produtoRepositoryMock.Verify(
            repository => repository.ObterProdutosPorNomeAsync(parteNome, It.IsAny<CancellationToken>()),
            Times.Once);
    }

    [Fact(DisplayName = "Deve obter um produto pelo identificador quando ele existir.")]
    public async Task ObterPorIdAsync_DeveRetornarProduto_QuandoIdentificadorExistir()
    {
        // Arrange
        var produto = ProdutoDtoMock.ProdutoValido();

        _produtoRepositoryMock
            .Setup(repository => repository.ObterProdutosPorIdAsync(produto.IdProduto, It.IsAny<CancellationToken>()))
            .ReturnsAsync(produto);

        var service = CriarService();

        // Act
        var resultado = await service.ObterPorIdAsync(produto.IdProduto);

        // Assert
        resultado.Ok.Should().BeTrue();
        resultado.NotFound.Should().BeFalse();
        resultado.Data.Should().NotBeNull();
        resultado.Data!.IdProduto.Should().Be(produto.IdProduto);
        resultado.Data.Nome.Should().Be(produto.Nome);
    }

    [Fact(DisplayName = "Deve cadastrar um produto sem componentes.")]
    public async Task AdicionarAsync_DeveCadastrarProdutoSemComponentes()
    {
        // Arrange
        var dto = ProdutoDtoMock.CreateProdutoDtoSemComponentes();
        Produto? produtoAdicionado = null;

        _produtoRepositoryMock
            .Setup(repository => repository.Adicionar(It.IsAny<Produto>()))
            .Callback<Produto>(produto => produtoAdicionado = produto);

        _unitOfWorkMock
            .Setup(unitOfWork => unitOfWork.SaveChangesAsync(It.IsAny<CancellationToken>()))
            .ReturnsAsync(1);

        var service = CriarService();

        // Act
        var resultado = await service.AdicionarAsync(dto);

        // Assert
        resultado.Ok.Should().BeTrue();
        salvo.Should().NotBeNull();
        salvo!.PrecoCusto.Should().Be(0);
        salvo.TempoImpressaoMinutos.Should().Be(45);
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
            Componentes = [new ProdutoComponenteDto { IdProdutoFilho = id, Quantidade = 1 }]
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
            Componentes = [new ProdutoComponenteDto { IdProdutoFilho = b, Quantidade = 1 }]
        };

        // Act
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
            Componentes =
            [
                new ProdutoComponenteDto { IdProdutoFilho = Guid.NewGuid(), Quantidade = 1 },
                new ProdutoComponenteDto { IdProdutoFilho = Guid.NewGuid(), Quantidade = 1 },
                new ProdutoComponenteDto { IdProdutoFilho = Guid.NewGuid(), Quantidade = 1 }
            ]
        };

        // Act
        var resultado = await service.AtualizarAsync(dto);

        // Assert
        resultado.Ok.Should().BeTrue();
        repository.Verify(x => x.Atualizar(It.Is<Produto>(p => p.ComposicoesPai.Count == 3)), Times.Once);
    }
}
