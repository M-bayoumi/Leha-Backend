using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Clients.Quaries.Models;

public class GetClientByIdQuery : IRequest<Response<GetClientByIdResponse>>
{
    public int Id { get; set; }

    public GetClientByIdQuery(int clientID)
    {
        Id = clientID;
    }
    public GetClientByIdQuery()
    {
    }
}
