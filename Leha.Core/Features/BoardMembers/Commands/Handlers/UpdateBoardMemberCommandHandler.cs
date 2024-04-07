using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMembers;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMembers.Commands.Handlers;

public class UpdateBoardMemberCommandHandler : ResponseHandler, IRequestHandler<UpdateBoardMemberCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateBoardMemberCommandHandler(IBoardMemberManager boardMemberManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateBoardMemberCommand request, CancellationToken cancellationToken)
    {
        var boardMember = await _boardMemberManager.GetBoardMemberByIDAsync(request.ID);

        if (boardMember == null) return NotFound<string>("");

        boardMember = _mapper.Map<BoardMember>(request);

        if (await _boardMemberManager.UpdateBoardMemberAsync(boardMember))
            return Created("");

        return BadRequest<string>("");
    }
    #endregion
}
