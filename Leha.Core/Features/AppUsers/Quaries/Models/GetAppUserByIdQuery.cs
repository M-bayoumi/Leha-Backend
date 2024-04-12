using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.AppUsers.Quaries.Models;


public class GetAppUserByIdQuery : IRequest<Response<GetAppUserByIdResponse>>
{
    public string Id { get; set; }

    public GetAppUserByIdQuery(string userId)
    {
        Id = userId;
    }
    public GetAppUserByIdQuery()
    {
    }
}

