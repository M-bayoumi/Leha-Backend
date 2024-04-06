using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Jobs.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Jobs.Quaries.Models;

public class GetJobListQuery : IRequest<Response<List<GetJobListResponse>>>
{
}
