using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Models;

public class AddProjectCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public string SiteEngineerNameAr { get; set; } = string.Empty;
    public string SiteEngineerNameEn { get; set; } = string.Empty;
    public decimal ProjectProgressPercentage { get; set; }
    public int CompanyId { get; set; }

    public AddProjectCommand()
    {

    }

    public AddProjectCommand(
        string nameAr, string nameEn,
        string descriptionAr, string descriptionEn,
        string addressAr, string addressEn,
        string image, string siteEngineerNameAr,
        string siteEngineerNameEn, decimal projectProgressPercentage,
        int companyId)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        AddressAr = addressAr;
        AddressEn = addressEn;
        Image = image;
        SiteEngineerNameAr = siteEngineerNameAr;
        SiteEngineerNameEn = siteEngineerNameEn;
        ProjectProgressPercentage = projectProgressPercentage;
        CompanyId = companyId;
    }
}
