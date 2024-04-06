using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Projects.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Projects.Quaries.Models;

public class GetProjectListQuery : IRequest<Response<List<GetProjectListResponse>>>
{
}
