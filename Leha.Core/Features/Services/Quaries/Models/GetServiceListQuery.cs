using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Services.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Services.Quaries.Models;

public class GetServiceListQuery : IRequest<Response<List<GetServiceListResponse>>>
{
}
