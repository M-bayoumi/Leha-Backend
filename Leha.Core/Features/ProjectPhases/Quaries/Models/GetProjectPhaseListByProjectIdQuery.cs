using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.ProjectPhases.Quaries.Models;

public class GetProjectPhaseListByProjectIDQuery : IRequest<Response<List<GetProjectPhaseListByProjectIDResponse>>>
{
    public int Id { get; set; }

    public GetProjectPhaseListByProjectIDQuery(int companyID)
    {
        Id = companyID;
    }
    public GetProjectPhaseListByProjectIDQuery()
    {
    }
}
