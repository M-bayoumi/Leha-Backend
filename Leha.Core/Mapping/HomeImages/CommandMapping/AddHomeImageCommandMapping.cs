using AutoMapper;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.HomeImages;


public partial class HomeImageProfile : Profile
{
    public void AddHomeImageCommandMapping()
    {
        CreateMap<AddHomeImageCommand, HomeImage>();
    }
}
