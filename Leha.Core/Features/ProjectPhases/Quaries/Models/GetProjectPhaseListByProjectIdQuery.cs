using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseListByProjectIdQuery : IRequest<Response<List<GetProjectPhaseListByProjectIDResponse>>>
{
    public int ID { get; set; }

    public GetProjectPhaseListByProjectIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetProjectPhaseListByProjectIdQuery()
    {
    }
}
