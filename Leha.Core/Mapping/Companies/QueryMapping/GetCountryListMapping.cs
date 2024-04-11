﻿using AutoMapper;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Companies;

public partial class CompanyProfile : Profile
{
    public void GetCountryListMapping()
    {
        CreateMap<Company, GetCompanyListResponse>()
             .ForMember(dist => dist.Name, opt => opt.MapFrom(src => src.GetLocalized(src.NameAr, src.NameEn)));

    }
}
