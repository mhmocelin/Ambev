using AutoMapper;

namespace Ambev.DeveloperEvaluation.Application.Product.UpdateProduct;

public class UpdateProductProfile: Profile
{
    public UpdateProductProfile()
    {
        CreateMap<UpdateProductCommand, Domain.Entities.Product>();
        CreateMap<UpdateRatingCommand, Domain.Entities.Rating>();

        CreateMap<Domain.Entities.Product, UpdateProductResult>();
        CreateMap<Domain.Entities.Rating, UpdateRatingResult>();
    }
}
