using AutoMapper;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Forms;


public partial class FormProfile : Profile
{
    public void UpdateFormCommandMapping()
    {
        CreateMap<UpdateFormCommand, Form>();
    }
}