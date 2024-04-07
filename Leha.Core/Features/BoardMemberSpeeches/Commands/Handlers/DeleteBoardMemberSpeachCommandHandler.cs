using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMemberSpeachSpeeches.Commands.Handlers;

public class DeleteBoardMemberSpeachCommandHandler : ResponseHandler, IRequestHandler<DeleteBoardMemberSpeachCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeachManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteBoardMemberSpeachCommandHandler(IBoardMemberSpeechManager boardMemberSpeachManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeachManager = boardMemberSpeachManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteBoardMemberSpeachCommand request, CancellationToken cancellationToken)
    {
        var boardMemberSpeech = await _boardMemberSpeachManager.GetBoardMemberSpeechByIDAsync(request.ID);
        if (boardMemberSpeech == null) return NotFound<string>("BoardMember not found");
        if (await _boardMemberSpeachManager.DeleteBoardMemberSpeechAsync(boardMemberSpeech))
            return Deleted<string>("Deleted Successfully");
        return BadRequest<string>();
    }

    #endregion
}
