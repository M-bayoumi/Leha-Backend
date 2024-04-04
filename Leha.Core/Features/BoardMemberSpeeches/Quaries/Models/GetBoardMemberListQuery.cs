using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;

public class GetBoardMemberSpeechListQuery : IRequest<Response<List<GetBoardMemberSpeechListResponse>>>
{
}

