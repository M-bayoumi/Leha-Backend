using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Models;

public class UpdateProjectPhaseCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ProjectPhaseName { get; set; } = string.Empty;
    public int ProjectID { get; set; }
    public UpdateProjectPhaseCommand()
    {

    }

    public UpdateProjectPhaseCommand(int iD, string projectPhaseName, int projectID)
    {
        ID = iD;
        ProjectPhaseName = projectPhaseName;
        ProjectID = projectID;
    }
}
