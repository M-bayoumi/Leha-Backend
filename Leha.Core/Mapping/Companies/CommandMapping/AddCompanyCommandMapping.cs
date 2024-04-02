using AutoMapper;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Companies;

public partial class CompanyProfile : Profile
{
    public void AddCompanyCommandMapping()
    {
        CreateMap<AddCompanyCommand, Company>();
    }
}
