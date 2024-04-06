using AutoMapper;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Products;


public partial class ProductProfile : Profile
{
    public void UpdateProductCommandMapping()
    {
        CreateMap<UpdateProductCommand, Product>();
    }
}