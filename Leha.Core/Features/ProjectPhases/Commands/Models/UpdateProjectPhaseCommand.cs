using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Commands.Models;

public class UpdateProjectPhaseCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public UpdateProjectPhaseCommand()
    {

    }

    public UpdateProjectPhaseCommand(int id, string nameAr, string nameEn, int projectId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        ProjectId = projectId;
    }
}
