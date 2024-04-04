using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Handlers;

public class GetBoardMemberSpeechesListByBoardMemberIdQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechesListByBoardMemberIdQuery, Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechesListByBoardMemberIdQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>> Handle(GetBoardMemberSpeechesListByBoardMemberIdQuery request, CancellationToken cancellationToken)
    {
        var boardMemberSpeechListDB = await _boardMemberSpeechManager.GetBoardMemberSpeechesListByBoardMemberId(request.ID).Include(x => x.BoardMember).ToListAsync();
        if (boardMemberSpeechListDB is null)
        {
            return NotFound<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>();
        }
        var boardMemberSpeechListMapper = _mapper.Map<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>(boardMemberSpeechListDB);
        return Success(boardMemberSpeechListMapper);
    }
    #endregion

}

