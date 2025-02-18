using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCartById;

public class GetCartByIdHandler : IRequestHandler<GetCartByIdCommand, GetCartByIdResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetCartByIdHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<GetCartByIdResult> Handle(GetCartByIdCommand command, CancellationToken cancellationToken)
    {
        var validator = new GetCartByIdValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);

        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {command.Id} not found");

        var result = _mapper.Map<GetCartByIdResult>(cart);
        return result;
    }
}
