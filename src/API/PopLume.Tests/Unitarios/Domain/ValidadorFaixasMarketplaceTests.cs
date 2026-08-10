using FluentAssertions;
using PopLume.Domain.Entities;
using PopLume.Domain.Precificacao;
using Xunit;

namespace PopLume.Tests.Unitarios.Domain;

public class ValidadorFaixasMarketplaceTests
{
    [Fact]
    public void PossuiSobreposicao_DeveDetectarFaixasSobrepostas()
    {
        var taxas = new[]
        {
            new TaxasMarketplace { ValorInicial = 0, ValorFinal = 20 },
            new TaxasMarketplace { ValorInicial = 20, ValorFinal = 50 }
        };
        ValidadorFaixasMarketplace.PossuiSobreposicao(taxas).Should().BeTrue();
    }

    [Fact]
    public void PossuiSobreposicao_DeveAceitarUltimaFaixaSemLimite()
    {
        var taxas = new[]
        {
            new TaxasMarketplace { ValorInicial = 0, ValorFinal = 20 },
            new TaxasMarketplace { ValorInicial = 20.01m, ValorFinal = null }
        };
        ValidadorFaixasMarketplace.PossuiSobreposicao(taxas).Should().BeFalse();
    }
}
