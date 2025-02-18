using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.PutCart;

public class PutCartHandler : IRequestHandler<PutCartCommand, PutCartResult>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public PutCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<PutCartResult> Handle(PutCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new PutCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);

        if (cart == null)
            throw new KeyNotFoundException($"Cart with ID {command.Id} not found");

        var cartToUpdate = _mapper.Map<Domain.Entities.Cart>(command);

        var updatedCart = await _cartRepository.UpdateAsync(cartToUpdate, cancellationToken);

        var result = _mapper.Map<PutCartResult>(updatedCart);
        return result;
    }
}
