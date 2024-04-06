using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Projects.Commands.Models;

public class AddProjectCommand : IRequest<Response<string>>
{
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string SiteEngineerName { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddProjectCommand()
    {

    }

    public AddProjectCommand(string projectName, string projectDescription, string projectAddress, string projectImage, string siteEngineerName, int companyID)
    {
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        ProjectAddress = projectAddress;
        ProjectImage = projectImage;
        SiteEngineerName = siteEngineerName;
        CompanyID = companyID;
    }
}
