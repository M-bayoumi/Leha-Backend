using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Projects.Quaries.Models;

public class GetProjectDetailsQuery : IRequest<Response<GetProjectDetailsResponse>>
{
    public int Id { get; set; }

    public GetProjectDetailsQuery(int projectID)
    {
        Id = projectID;
    }
    public GetProjectDetailsQuery()
    {
    }
}
