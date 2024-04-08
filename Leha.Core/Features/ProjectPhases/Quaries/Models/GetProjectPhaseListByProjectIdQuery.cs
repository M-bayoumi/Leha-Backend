using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseListByProjectIDQuery : IRequest<Response<List<GetProjectPhaseListByProjectIDResponse>>>
{
    public int ID { get; set; }

    public GetProjectPhaseListByProjectIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetProjectPhaseListByProjectIDQuery()
    {
    }
}
