using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Models;

public class AddProjectPhaseCommand : IRequest<Response<string>>
{
    public string ProjectPhaseName { get; set; } = string.Empty;
    public int ProjectID { get; set; }

    public AddProjectPhaseCommand()
    {

    }

    public AddProjectPhaseCommand(string projectPhaseName, int projectID)
    {
        ProjectPhaseName = projectPhaseName;
        ProjectID = projectID;
    }
}
