using FluentValidation;
using PopDesing.Application.Dtos;

namespace PopDesing.Application.Validators;

public class CreateEquipamentoValidator : AbstractValidator<EquipamentoCreateDto>
{
    public CreateEquipamentoValidator()
    {
        /*
        RuleFor(x => x.IdCliente)
            .GreaterThan(0).WithMessage("O Id do cliente é obrigatório e deve ser maior que zero.");
        */
    }
}
