using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMembers;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMemberSpeachSpeeches.Commands.Handlers;

public class AddBoardMemberSpeachCommandHandler : ResponseHandler, IRequestHandler<AddBoardMemberSpeechCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeachManager;
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors
    public AddBoardMemberSpeachCommandHandler(IBoardMemberSpeechManager boardMemberSpeachManager, IBoardMemberManager boardMemberManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeachManager = boardMemberSpeachManager;
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }

    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddBoardMemberSpeechCommand request, CancellationToken cancellationToken)
    {
        var boardMember = await _boardMemberManager.GetByIdAsync(request.BoardMemberID);
        if (boardMember != null)
        {
            var boardMemberSpeach = _mapper.Map<BoardMemberSpeech>(request);
            if (await _boardMemberSpeachManager.AddAsync(boardMemberSpeach))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");

    }

    #endregion
}
