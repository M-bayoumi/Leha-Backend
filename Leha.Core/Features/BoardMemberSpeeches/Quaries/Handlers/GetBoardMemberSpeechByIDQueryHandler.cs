﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Handlers;

public class GetBoardMemberSpeechByIDQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechByIDQuery, Response<GetBoardMemberSpeechByIDResponse>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechByIDQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberSpeechByIDResponse>> Handle(GetBoardMemberSpeechByIDQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberSpeechManager.GetBoardMemberSpeechByIDAsync(request.ID);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberSpeechByIDResponse>();
        }
        var boardMemberSpeechMapper = _mapper.Map<GetBoardMemberSpeechByIDResponse>(boardMemberDB);
        return Success(boardMemberSpeechMapper);
    }
    #endregion

}
