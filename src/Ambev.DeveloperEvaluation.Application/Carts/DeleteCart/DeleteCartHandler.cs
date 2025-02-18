using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;

namespace Ambev.DeveloperEvaluation.Application.Carts.DeleteCart;

public  class DeleteCartHandler : IRequestHandler<DeleteCartCommand, DeleteCartResult>
{
    private readonly ICartRepository _carttRepository;
    private readonly IMapper _mapper;

    public DeleteCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _carttRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<DeleteCartResult> Handle(DeleteCartCommand command, CancellationToken cancellationToken)
    {
        var validator = new DeleteCartValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _carttRepository.GetByIdAsync(command.Id, cancellationToken);
        if (product == null)
            throw new KeyNotFoundException($"Cart not found");

        await _carttRepository.DeleteByIdAsync(command.Id, cancellationToken);

        var result = new DeleteCartResult() { message = "successful deleted" };
        return result;
    }
}
