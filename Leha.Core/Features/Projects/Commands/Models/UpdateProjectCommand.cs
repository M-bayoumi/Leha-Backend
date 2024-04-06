using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Models;

public class UpdateProjectCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string SiteEngineerName { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public UpdateProjectCommand()
    {

    }

    public UpdateProjectCommand(int iD, string projectName, string projectDescription, string projectAddress, string projectImage, string siteEngineerName, int companyID)
    {
        ID = iD;
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        ProjectAddress = projectAddress;
        ProjectImage = projectImage;
        SiteEngineerName = siteEngineerName;
        CompanyID = companyID;
    }
}
