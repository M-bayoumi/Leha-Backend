using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.BoardMemberSpeeches;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMemberSpeeches.Quaries.Handlers;

public class GetBoardMemberSpeechByIdQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberSpeechByIdQuery, Response<GetBoardMemberSpeechByIdResponse>>
{
    #region Fields
    private readonly IBoardMemberSpeechManager _boardMemberSpeechManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberSpeechByIdQueryHandler(IBoardMemberSpeechManager boardMemberSpeechManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberSpeechManager = boardMemberSpeechManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberSpeechByIdResponse>> Handle(GetBoardMemberSpeechByIdQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberSpeechManager.GetAll().Include(x => x.BoardMember).FirstOrDefaultAsync(x => x.Id == request.Id);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberSpeechByIdResponse>();
        }
        var boardMemberSpeechMapper = _mapper.Map<GetBoardMemberSpeechByIdResponse>(boardMemberDB);
        return Success(boardMemberSpeechMapper);
    }
    #endregion

}

