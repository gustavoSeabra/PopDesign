using FluentAssertions;
using PopLume.Domain.Entities;
using PopLume.Domain.Precificacao;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class ValidadorCicloProdutoTests
{
    [Fact]
    public void PossuiCiclo_DeveDetectarAutorrelacionamento()
    {
        var id = Guid.NewGuid();
        ValidadorCicloProduto.PossuiCiclo(id, id, []).Should().BeTrue();
    }

    [Fact]
    public void PossuiCiclo_DeveDetectarCicloIndireto()
    {
        var a = Guid.NewGuid();
        var b = Guid.NewGuid();
        var c = Guid.NewGuid();
        ProdutoComposicao[] existentes =
        [
            new() { IdProdutoPai = b, IdProdutoFilho = c, Quantidade = 1 },
            new() { IdProdutoPai = c, IdProdutoFilho = a, Quantidade = 1 }
        ];

        ValidadorCicloProduto.PossuiCiclo(a, b, existentes).Should().BeTrue();
    }

    [Fact]
    public void PossuiCiclo_DeveAceitarArvoreValida()
    {
        var kit = Guid.NewGuid();
        var chaveiro = Guid.NewGuid();
        var portaRetrato = Guid.NewGuid();

        ValidadorCicloProduto.PossuiCiclo(kit, chaveiro,
            [new ProdutoComposicao { IdProdutoPai = kit, IdProdutoFilho = portaRetrato, Quantidade = 1 }])
            .Should().BeFalse();
    }
}
