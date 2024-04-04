using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
namespace Leha.Core.Features.BoardMemberSpeachSpeeches.Commands.Handlers;

public class UpdateBoardMemberSpeachCommandHandler : ResponseHandler, IRequestHandler<UpdateBoardMemberSpeechCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeachManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateBoardMemberSpeachCommandHandler(IBoardMemberSpeechManager boardMemberSpeachManager, IMapper mapper)
    {
        _boardMemberSpeachManager = boardMemberSpeachManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateBoardMemberSpeechCommand request, CancellationToken cancellationToken)
    {
        var boardMemberSpeach = _mapper.Map<BoardMemberSpeech>(request);

        if (await _boardMemberSpeachManager.UpdateBoardMemberSpeechAsync(boardMemberSpeach))
            return Created("Board Member Speach Updated Successfully");

        return BadRequest<string>("Failed To Updat Board Member Speach");
    }

    #endregion
}
