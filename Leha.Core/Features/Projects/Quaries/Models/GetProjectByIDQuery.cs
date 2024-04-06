using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Projects.Quaries.Models;

public class GetProjectByIDQuery : IRequest<Response<GetProjectByIDResponse>>
{
    public int ID { get; set; }

    public GetProjectByIDQuery(int projectID)
    {
        ID = projectID;
    }
    public GetProjectByIDQuery()
    {
    }
}
