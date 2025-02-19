using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Carts.GetCartById;

public class GetCartRequestValidator : AbstractValidator<GetCartByIdRequest>
{
    public GetCartRequestValidator() 
    {
        RuleFor(p => p.Id).NotEmpty();
    }
}
