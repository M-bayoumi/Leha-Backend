using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseDetailsQuery : IRequest<Response<GetProjectPhaseDetailsResponse>>
{
    public int Id { get; set; }

    public GetProjectPhaseDetailsQuery(int projectPhaseID)
    {
        Id = projectPhaseID;
    }
    public GetProjectPhaseDetailsQuery()
    {
    }
}
