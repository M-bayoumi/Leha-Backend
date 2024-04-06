using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMembers;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
namespace Leha.Core.Features.BoardMemberSpeachSpeeches.Commands.Handlers;

public class UpdateBoardMemberSpeachCommandHandler : ResponseHandler, IRequestHandler<UpdateBoardMemberSpeechCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeachManager;
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors
    public UpdateBoardMemberSpeachCommandHandler(IBoardMemberSpeechManager boardMemberSpeachManager, IBoardMemberManager boardMemberManager, IMapper mapper)
    {
        _boardMemberSpeachManager = boardMemberSpeachManager;
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }

    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateBoardMemberSpeechCommand request, CancellationToken cancellationToken)
    {
        var boardMember = await _boardMemberManager.GetBoardMemberByIDAsync(request.BoardMemberID); // GetById without without include 
        if (boardMember != null)
        {
            var boardMemberSpeach = _mapper.Map<BoardMemberSpeech>(request);

            if (await _boardMemberSpeachManager.UpdateBoardMemberSpeechAsync(boardMemberSpeach))
                return Created("Board Member Speach Updated Successfully");
            return BadRequest<string>("Failed To Update Board Member Speach");
        }
        return NotFound<string>("BoardMember not found");

    }

    #endregion
}
