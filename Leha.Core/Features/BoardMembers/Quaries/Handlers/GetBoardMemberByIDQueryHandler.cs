﻿
using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMembers.Quaries.Models;
using Leha.Core.Features.BoardMembers.Quaries.Results;
using Leha.Core.Features.Companies.Queries.Models;
using Leha.Core.Features.Companies.Queries.Results;
using Leha.Manager.Managers.BoardMembers;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.BoardMembers.Queries.Handlers;

public class GetBoardMemberByIDQueryHandler : ResponseHandler, IRequestHandler<GetBoardMemberByIDQuery, Response<GetBoardMemberByIDResponse>>
{
    #region Fields
    private readonly IBoardMemberManager _boardMemberManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetBoardMemberByIDQueryHandler(IBoardMemberManager boardMemberManager, IMapper mapper)
    {
        _boardMemberManager = boardMemberManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetBoardMemberByIDResponse>> Handle(GetBoardMemberByIDQuery request, CancellationToken cancellationToken)
    {
        var boardMemberDB = await _boardMemberManager.GetBoardMemberByIDAsync(request.ID);
        if (boardMemberDB is null)
        {
            return NotFound<GetBoardMemberByIDResponse>();
        }
        var boardMemberMapper = _mapper.Map<GetBoardMemberByIDResponse>(boardMemberDB);
        return Success(boardMemberMapper);
    }
    #endregion

}