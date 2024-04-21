using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Clients.Quaries.Models;

public class GetClientDetailsQuery : IRequest<Response<GetClientDetailsResponse>>
{
    public int Id { get; set; }

    public GetClientDetailsQuery(int clientID)
    {
        Id = clientID;
    }
    public GetClientDetailsQuery()
    {
    }
}
