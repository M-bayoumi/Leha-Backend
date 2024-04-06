using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseByIDQuery : IRequest<Response<GetProjectPhaseByIDResponse>>
{
    public int ID { get; set; }

    public GetProjectPhaseByIDQuery(int projectPhaseID)
    {
        ID = projectPhaseID;
    }
    public GetProjectPhaseByIDQuery()
    {
    }
}
