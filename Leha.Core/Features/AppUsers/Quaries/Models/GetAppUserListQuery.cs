using Leha.Core.BaseResponse;
using Leha.Core.Features.AppUsers.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.AppUsers.Quaries.Models;

public class GetAppUserListQuery : IRequest<Response<GetAppUserListResponse>>
{
}
