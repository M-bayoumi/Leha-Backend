using AutoMapper;
using Leha.Core.Features.Products.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Products;
public partial class ProductProfile : Profile
{
    public void GetProductDetailsMapping()
    {
        CreateMap<Product, GetProductDetailsResponse>();
    }
}
