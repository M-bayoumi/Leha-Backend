using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Services.Quaries.Models;

public class GetServiceByIdQuery : IRequest<Response<GetServiceByIdResponse>>
{
    public int Id { get; set; }

    public GetServiceByIdQuery(int serviceID)
    {
        Id = serviceID;
    }
    public GetServiceByIdQuery()
    {
    }
}
