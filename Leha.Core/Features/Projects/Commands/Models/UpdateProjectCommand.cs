using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Models;

public class UpdateProjectCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
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
    public UpdateProjectCommand()
    {

    }

    public UpdateProjectCommand(int id,
        string nameAr, string nameEn,
        string descriptionAr, string descriptionEn,
        string addressAr, string addressEn,
        string image,
        string siteEngineerNameAr, string siteEngineerNameEn,
        decimal projectProgressPercentage,
        int companyId)
    {
        Id = id;
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
