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

public class GetBoardMemberSpeechDetailsQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechDetailsQuery, Response<GetBoardMemberSpeechDetailsResponse>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechDetailsQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberSpeechDetailsResponse>> Handle(GetBoardMemberSpeechDetailsQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberSpeechManager.GetAll().Include(x => x.BoardMember).FirstOrDefaultAsync(x => x.Id == request.Id);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberSpeechDetailsResponse>();
        }
        var boardMemberSpeechMapper = _mapper.Map<GetBoardMemberSpeechDetailsResponse>(boardMemberDB);
        return Success(boardMemberSpeechMapper);
    }
    #endregion

}

