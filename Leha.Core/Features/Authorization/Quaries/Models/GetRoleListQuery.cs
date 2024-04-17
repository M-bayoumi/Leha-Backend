using Leha.Core.BaseResponse;
using Leha.Core.Features.Authorization.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Authorization.Quaries.Models;

public class GetRoleListQuery : IRequest<Response<List<GetRoleListResponse>>>
{
}
