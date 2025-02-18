﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Product.DeleteProduct;

public class DeleteProductCommand : IRequest<DeleteProductResult>
{
    public Guid Id { get; set; }
    public DeleteProductCommand(Guid id) => Id = id;
}
