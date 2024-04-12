using AutoMapper;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Companies;

public partial class CompanyProfile : Profile
{
    public void GetCompanyByIdMapping()
    {
        CreateMap<Company, GetCompanyByIdResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)))
             .ForMember(dist => dist.Slogan, opt => opt.MapFrom(src => src.GetLocalized(src.SloganAr, src.SloganEn)));

    }
}
