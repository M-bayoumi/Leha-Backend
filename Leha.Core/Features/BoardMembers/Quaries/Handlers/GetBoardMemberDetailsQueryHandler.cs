
using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.BoardMembers;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.BoardMembers.Queries.Handlers;

public class GetBoardMemberDetailsQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberDetailsQuery, Response<GetBoardMemberDetailsResponse>>
{
    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberDetailsQueryHandler(IBoardMemberManager boardMemberManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberDetailsResponse>> Handle(GetBoardMemberDetailsQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberManager.GetByIdAsync(request.Id);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberDetailsResponse>();
        }
        var boardMemberMapper = _mapper.Map<GetBoardMemberDetailsResponse>(boardMemberDB);
        return Success(boardMemberMapper);
    }
    #endregion

}
