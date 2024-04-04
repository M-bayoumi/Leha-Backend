﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMembers;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Handlers;

public class UpdateBoardMemberCommandHandler : ResponseHandler, IRequestHandler<UpdateBoardMemberSpeechCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateBoardMemberCommandHandler(IBoardMemberManager boardMemberManager, IMapper mapper)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateBoardMemberSpeechCommand request, CancellationToken cancellationToken)
    {
        var boardMember = _mapper.Map<BoardMember>(request);

        if (await _boardMemberManager.UpdateBoardMemberAsync(boardMember))
            return Created("Board Member Updated Successfully");

        return BadRequest<string>("Failed To Update Board Member");
    }
    #endregion
}
