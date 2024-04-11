using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Models;

public class AddProjectPhaseCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int ProjectId { get; set; }

    public AddProjectPhaseCommand()
    {

    }

    public AddProjectPhaseCommand(string nameAr, string nameEn, int projectId)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        ProjectId = projectId;
    }
}
