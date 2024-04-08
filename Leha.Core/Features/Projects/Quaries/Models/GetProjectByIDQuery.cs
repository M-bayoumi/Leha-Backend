using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Projects.Quaries.Models;

public class GetProjectByIdQuery : IRequest<Response<GetProjectByIdResponse>>
{
    public int ID { get; set; }

    public GetProjectByIdQuery(int projectID)
    {
        ID = projectID;
    }
    public GetProjectByIdQuery()
    {
    }
}
