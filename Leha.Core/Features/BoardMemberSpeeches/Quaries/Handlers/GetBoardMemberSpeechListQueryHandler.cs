﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Handlers;

public class GetBoardMemberSpeechListQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechListQuery, Response<List<GetBoardMemberSpeechListResponse>>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechListQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetBoardMemberSpeechListResponse>>> Handle(GetBoardMemberSpeechListQuery request, CancellationToken cancellationToken)
    {
        var boardMemberSpeechListDB = await _boardMemberSpeechManager.GetBoardMemberSpeechesListAsync().Include(x => x.BoardMember).ToListAsync();
        if (boardMemberSpeechListDB is null)
        {
            return NotFound<List<GetBoardMemberSpeechListResponse>>();
        }
        var boardMemberSpeechListMapper = _mapper.Map<List<GetBoardMemberSpeechListResponse>>(boardMemberSpeechListDB);
        return Success(boardMemberSpeechListMapper);
    }
    #endregion

}

