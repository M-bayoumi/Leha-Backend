using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormListQuery : IRequest<Response<List<GetFormListResponse>>>
{
}
