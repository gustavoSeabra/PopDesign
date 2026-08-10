using FluentValidation;
using PopLume.Application.Dtos;

namespace PopLume.Application.Validators;

public class CreateProdutoValidator : AbstractValidator<CreateProdutoDto>
{
    public CreateProdutoValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.TempoImpressaoMinutos).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TempoMaoDeObraMinutos).GreaterThanOrEqualTo(0);
        RuleForEach(x => x.Variacoes).SetValidator(new ProdutoVariacaoInputValidator());
        RuleForEach(x => x.Insumos).SetValidator(new ProdutoInsumoInputValidator());
        RuleForEach(x => x.Componentes).SetValidator(new ProdutoComponenteValidator());
        RuleFor(x => x.Variacoes).Must(NaoPossuirVariacoesDuplicadas).WithMessage("Uma variação não pode ser repetida no produto.");
        RuleFor(x => x.Insumos).Must(NaoPossuirInsumosDuplicados).WithMessage("Um insumo não pode ser repetido no produto.");
        RuleFor(x => x.Componentes).Must(NaoPossuirComponentesDuplicados).WithMessage("Um componente não pode ser repetido no produto.");
    }

    private static bool NaoPossuirVariacoesDuplicadas(List<ProdutoVariacaoInputDto>? itens) =>
        itens is null || itens.Select(x => x.Nome.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).Count() == itens.Count;
    private static bool NaoPossuirInsumosDuplicados(List<ProdutoInsumoInputDto>? itens) =>
        itens is null || itens.Select(x => x.IdInsumo).Distinct().Count() == itens.Count;
    private static bool NaoPossuirComponentesDuplicados(List<ProdutoComponenteDto>? itens) =>
        itens is null || itens.Select(x => (x.IdProdutoFilho, x.IdProdutoVariacaoFilho)).Distinct().Count() == itens.Count;
}

public class UpdateProdutoValidator : AbstractValidator<UpdateProdutoDto>
{
    public UpdateProdutoValidator()
    {
        RuleFor(x => x.IdProduto).NotEmpty();
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(100);
        RuleFor(x => x.TempoImpressaoMinutos).GreaterThanOrEqualTo(0);
        RuleFor(x => x.TempoMaoDeObraMinutos).GreaterThanOrEqualTo(0);
        RuleForEach(x => x.Variacoes).SetValidator(new ProdutoVariacaoInputValidator());
        RuleFor(x => x.Variacoes)
            .Must(x => x is null || x.Select(v => v.Nome.Trim()).Distinct(StringComparer.OrdinalIgnoreCase).Count() == x.Count)
            .WithMessage("Uma variação não pode ser repetida no produto.");
        RuleForEach(x => x.Insumos).SetValidator(new ProdutoInsumoInputValidator());
        RuleForEach(x => x.Componentes).SetValidator(new ProdutoComponenteValidator());
        RuleForEach(x => x.Componentes)
            .Must((dto, componente, _) => componente.IdProdutoFilho != dto.IdProduto)
            .WithMessage("Um produto não pode conter a si próprio.");
    }
}

public class ProdutoVariacaoInputValidator : AbstractValidator<ProdutoVariacaoInputDto>
{
    public ProdutoVariacaoInputValidator()
    {
        RuleFor(x => x.Nome).NotEmpty().MaximumLength(50);
        RuleFor(x => x.CodigoInterno).MaximumLength(50);
        RuleFor(x => x.Filamentos).NotEmpty().WithMessage("A variação deve possuir pelo menos um filamento.");
        RuleForEach(x => x.Filamentos).SetValidator(new ProdutoVariacaoFilamentoInputValidator());
        RuleFor(x => x.Filamentos)
            .Must(x => x.Select(f => f.IdFilamento).Distinct().Count() == x.Count)
            .WithMessage("Um filamento não pode ser repetido na mesma variação.");
    }
}

public class ProdutoVariacaoFilamentoInputValidator : AbstractValidator<ProdutoVariacaoFilamentoInputDto>
{
    public ProdutoVariacaoFilamentoInputValidator()
    {
        RuleFor(x => x.IdFilamento).NotEmpty();
        RuleFor(x => x.QuantidadeGramas).GreaterThan(0);
        RuleFor(x => x.PercentualPerda).InclusiveBetween(0, 100);
    }
}

public class ProdutoInsumoInputValidator : AbstractValidator<ProdutoInsumoInputDto>
{
    public ProdutoInsumoInputValidator()
    {
        RuleFor(x => x.IdInsumo).NotEmpty();
        RuleFor(x => x.QuantidadeUtilizada).GreaterThan(0);
    }
}

public class ProdutoComponenteValidator : AbstractValidator<ProdutoComponenteDto>
{
    public ProdutoComponenteValidator()
    {
        RuleFor(x => x.IdProdutoFilho).NotEmpty();
        RuleFor(x => x.IdProdutoVariacaoFilho).NotEmpty();
        RuleFor(x => x.Quantidade).GreaterThan(0);
    }
}
