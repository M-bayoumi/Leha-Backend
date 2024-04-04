using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Manager.Managers.BoardMembers;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Queries.Handlers;

public class GetBoardMemberListQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberListQuery, Response<List<GetBoardMemberListResponse>>>
{
    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberListQueryHandler(IBoardMemberManager boardMemberManager, IMapper mapper)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetBoardMemberListResponse>>> Handle(GetBoardMemberListQuery request, CancellationToken cancellationToken)
    {
        var boardMemberListDB = await _boardMemberManager.GetBoardMembersListAsync();
        var boardMemberListMapper = _mapper.Map<List<GetBoardMemberListResponse>>(boardMemberListDB);
        return Success(boardMemberListMapper);
    }
    #endregion

}
