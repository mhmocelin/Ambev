﻿namespace Ambev.DeveloperEvaluation.Application.Carts.CreateCart;

public class CreateCartResult
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
    public IEnumerable<CreateCartProductResult> Products {get;set;}
}
