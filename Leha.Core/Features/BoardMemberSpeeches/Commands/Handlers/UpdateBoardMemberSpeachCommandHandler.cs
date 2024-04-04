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
public class DeleteBoardMemberSpeachCommandHandler : ResponseHandler, IRequestHandler<DeleteBoardMemberSpeachCommand, Response<string>>
{

    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeachManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteBoardMemberSpeachCommandHandler(IBoardMemberSpeechManager boardMemberSpeachManager, IMapper mapper)
    {
        _boardMemberSpeachManager = boardMemberSpeachManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteBoardMemberSpeachCommand request, CancellationToken cancellationToken)
    {
        var boardMemberSpeech = await _boardMemberSpeachManager.GetBoardMemberSpeechByIDAsync(request.ID); // GetById without without include 
        if (boardMemberSpeech == null) return NotFound<string>("BoardMember not found");
        return await _boardMemberSpeachManager.DeleteBoardMemberSpeechAsync(boardMemberSpeech) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}
