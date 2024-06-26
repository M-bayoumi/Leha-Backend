﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMembers;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMembers.Commands.Handlers;

public class AddBoardMemberCommandHandler : ResponseHandler, IRequestHandler<AddBoardMemberCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AddBoardMemberCommandHandler(IBoardMemberManager boardMemberManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddBoardMemberCommand request, CancellationToken cancellationToken)
    {
        var boardMember = _mapper.Map<BoardMember>(request);

        if (await _boardMemberManager.AddAsync(boardMember))
            return Created("");

        return BadRequest<string>("");
    }

    #endregion
}
