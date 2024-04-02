using AutoMapper;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Companies;

public partial class CompanyProfile : Profile
{
    public void UpdateCompanyCommandMapping()
    {
        CreateMap<UpdateCompanyCommand, Company>();
        //.ForMember(dest => dest.ID, opt => opt.Ignore()); // that is no neet to map id;
    }
}
