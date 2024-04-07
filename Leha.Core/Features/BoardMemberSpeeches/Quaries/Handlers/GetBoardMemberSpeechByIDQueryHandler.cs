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

public class GetBoardMemberSpeechByIDQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechByIDQuery, Response<GetBoardMemberSpeechByIDResponse>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechByIDQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberSpeechByIDResponse>> Handle(GetBoardMemberSpeechByIDQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberSpeechManager.GetBoardMemberSpeechesListAsync().Include(x => x.BoardMember).FirstOrDefaultAsync(x => x.ID == request.ID);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberSpeechByIDResponse>();
        }
        var boardMemberSpeechMapper = _mapper.Map<GetBoardMemberSpeechByIDResponse>(boardMemberDB);
        return Success(boardMemberSpeechMapper);
    }
    #endregion

}

