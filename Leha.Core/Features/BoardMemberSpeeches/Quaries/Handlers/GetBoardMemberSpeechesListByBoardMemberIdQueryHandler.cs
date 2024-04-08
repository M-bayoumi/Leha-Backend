using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Handlers;

public class GetBoardMemberSpeechesListByBoardMemberIDQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechesListByBoardMemberIDQuery, Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechesListByBoardMemberIDQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>> Handle(GetBoardMemberSpeechesListByBoardMemberIDQuery request, CancellationToken cancellationToken)
    {
        var boardMemberSpeechListDB = await _boardMemberSpeechManager.GetAllByBoardMemberID(request.ID).Include(x => x.BoardMember).ToListAsync();
        if (boardMemberSpeechListDB is null)
        {
            return NotFound<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>();
        }
        var boardMemberSpeechListMapper = _mapper.Map<List<GetBoardMemberSpeechListByBoardMemberIDResponse>>(boardMemberSpeechListDB);
        return Success(boardMemberSpeechListMapper);
    }
    #endregion

}

