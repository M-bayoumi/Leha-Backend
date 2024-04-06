using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Posts.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Posts.Quaries.Models;

public class GetPostListQuery : IRequest<Response<List<GetPostListResponse>>>
{
}
