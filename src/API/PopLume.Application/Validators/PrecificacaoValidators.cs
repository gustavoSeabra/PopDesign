using FluentValidation;
using PopLume.Application.Dtos;

namespace PopLume.Application.Validators;

public class CalcularPrecificacaoValidator : AbstractValidator<CalcularPrecificacaoDto>
{
    public CalcularPrecificacaoValidator()
    {
        RuleFor(x => x.IdEquipamento).NotEmpty();
        RuleFor(x => x.IdProdutoVariacao).NotEmpty();
        RuleFor(x => x.MargemPercentual).InclusiveBetween(0, 99.99m);
        RuleFor(x => x.QuantidadeProduzida).GreaterThan(0);
    }
}

public class CreateTarifaEnergiaValidator : AbstractValidator<CreateTarifaEnergiaDto>
{
    public CreateTarifaEnergiaValidator()
    {
        RuleFor(x => x.ValorKwh).NotNull().GreaterThan(0);
        RuleFor(x => x.InicioVigencia).NotNull();
        RuleFor(x => x.FimVigencia).GreaterThanOrEqualTo(x => x.InicioVigencia)
            .When(x => x.FimVigencia.HasValue && x.InicioVigencia.HasValue);
    }
}

public class CreateCustoMaoDeObraValidator : AbstractValidator<CreateCustoMaoDeObraDto>
{
    public CreateCustoMaoDeObraValidator()
    {
        RuleFor(x => x.ValorHora).NotNull().GreaterThan(0);
        RuleFor(x => x.InicioVigencia).NotNull();
        RuleFor(x => x.FimVigencia).GreaterThanOrEqualTo(x => x.InicioVigencia)
            .When(x => x.FimVigencia.HasValue && x.InicioVigencia.HasValue);
    }
}
