using Ambev.DeveloperEvaluation.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Carts.GetCart;

public class GetCartHandler : IRequestHandler<GetCartCommand, IEnumerable<GetCartResult>>
{
    private readonly ICartRepository _cartRepository;
    private readonly IMapper _mapper;

    public GetCartHandler(ICartRepository cartRepository, IMapper mapper)
    {
        _cartRepository = cartRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GetCartResult>> Handle(GetCartCommand command, CancellationToken cancellationToken)
    {
        var carts = await _cartRepository.GetAllAsync(cancellationToken);
        
        if (!carts.Any()) 
            throw new KeyNotFoundException($"No registered cart");

        var result = _mapper.Map<IEnumerable<GetCartResult>>(carts);
        return result;
    }
}
