using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Clients.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Clients.Quaries.Models;

public class GetClientListQuery : IRequest<Response<List<GetClientListResponse>>>
{
}
