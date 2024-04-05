using AutoMapper;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Clients;


public partial class ClientProfile : Profile
{
    public void UpdateClientCommandMapping()
    {
        CreateMap<UpdateClientCommand, Client>();
    }
}