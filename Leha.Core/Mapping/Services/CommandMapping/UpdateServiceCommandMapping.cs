using AutoMapper;
using Leha.Core.Features.Services.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Services;


public partial class ServiceProfile : Profile
{
    public void UpdateServiceCommandMapping()
    {
        CreateMap<UpdateServiceCommand, Service>();
    }
}