using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.BoardMembers;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMembers.Commands.Handlers;

public class DeleteBoardMemberCommandHandler : ResponseHandler, IRequestHandler<DeleteBoardMemberCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteBoardMemberCommandHandler(IBoardMemberManager boardMemberManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions

    public async Task<Response<string>> Handle(DeleteBoardMemberCommand request, CancellationToken cancellationToken)
    {
        var boardMember = await _boardMemberManager.GetBoardMemberByIDAsync(request.ID);

        if (boardMember == null) return NotFound<string>("");
        if (await _boardMemberManager.DeleteBoardMemberAsync(boardMember))
            return Deleted<string>("");

        return BadRequest<string>();
    }
    #endregion
}
