using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Commands.Models;
using Leha.Manager.Managers.BoardMembers;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Commands.Handlers;

public class DeleteBoardMemberCommandHandler : ResponseHandler, IRequestHandler<DeleteBoardMemberCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteBoardMemberCommandHandler(IBoardMemberManager boardMemberManager, IMapper mapper)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions

    public async Task<Response<string>> Handle(DeleteBoardMemberCommand request, CancellationToken cancellationToken)
    {
        var boardMember = await _boardMemberManager.GetBoardMemberByIDAsync(request.ID); // GetById without without include 
        if (boardMember == null) return NotFound<string>("BoardMember not found");
        return await _boardMemberManager.DeleteBoardMemberAsync(boardMember) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }
    #endregion
}
