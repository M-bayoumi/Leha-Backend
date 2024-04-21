using Leha.Core.BaseResponse;
using Leha.Core.Features.Services.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Services.Quaries.Models;

public class GetServiceDetailsQuery : IRequest<Response<GetServiceDetailsResponse>>
{
    public int Id { get; set; }

    public GetServiceDetailsQuery(int serviceID)
    {
        Id = serviceID;
    }
    public GetServiceDetailsQuery()
    {
    }
}
