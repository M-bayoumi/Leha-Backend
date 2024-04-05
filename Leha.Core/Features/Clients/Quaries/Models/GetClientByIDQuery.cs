using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Clients.Quaries.Models;

public class GetClientByIDQuery : IRequest<Response<GetClientByIDResponse>>
{
    public int ID { get; set; }

    public GetClientByIDQuery(int clientID)
    {
        ID = clientID;
    }
    public GetClientByIDQuery()
    {
    }
}
