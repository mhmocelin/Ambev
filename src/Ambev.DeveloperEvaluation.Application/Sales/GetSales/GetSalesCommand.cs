﻿using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales;

public class GetSalesCommand : IRequest<IEnumerable<GetSalesResult>>
{
}
