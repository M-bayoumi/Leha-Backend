using AutoMapper;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Forms;
public partial class FormProfile : Profile
{
    public void GetFormDetailsMapping()
    {
        CreateMap<Form, GetFormDetailsResponse>();
    }
}
