using FluentValidation;
using PopLume.Application.Dtos;

namespace PopLume.Application.Validators;

public class CreateInsumoValidator : AbstractValidator<CreateInsumoDto>
{
    public CreateInsumoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.ValorCompra).NotNull().GreaterThanOrEqualTo(0);
        RuleFor(x => x.QuantidadeComprada).NotNull().GreaterThan(0);
        RuleFor(x => x.UnidadeMedida).NotNull().IsInEnum();
    }
}

public class UpdateInsumoValidator : AbstractValidator<UpdateInsumoDto>
{
    public UpdateInsumoValidator()
    {
        Include(new CreateInsumoValidator());
        RuleFor(x => x.IdInsumo).NotEmpty();
    }
}
