using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseByIdQuery : IRequest<Response<GetProjectPhaseByIdResponse>>
{
    public int Id { get; set; }

    public GetProjectPhaseByIdQuery(int projectPhaseID)
    {
        Id = projectPhaseID;
    }
    public GetProjectPhaseByIdQuery()
    {
    }
}
