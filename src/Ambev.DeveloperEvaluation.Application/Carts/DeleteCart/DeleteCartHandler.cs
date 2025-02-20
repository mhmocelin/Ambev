using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public  class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _cartRepository;

    public DeleteCartHandler(ICartRepository cartRepository)
        => _cartRepository = cartRepository;

    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var cart = await _cartRepository.GetByIdAsync(command.Id, cancellationToken);
        if (cart == null)
            throw new KeyNotFoundException($"Cart not found");

        await _cartRepository.DeleteByIdAsync(command.Id, cancellationToken);

        var result = new DeleteCartResult() { message = "successful deleted" };
        return result;
    }
}
