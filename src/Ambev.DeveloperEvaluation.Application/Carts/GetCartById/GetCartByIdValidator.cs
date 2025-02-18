using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById;

public class GetCartByIdValidator : AbstractValidator<GetCartByIdCommand>
{
    public GetCartByIdValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("Cart ID is required");
    }
}
