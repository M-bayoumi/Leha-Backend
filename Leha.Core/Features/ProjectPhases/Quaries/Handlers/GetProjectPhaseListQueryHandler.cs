using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Models;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.ProjectPhases.Quaries.Handlers;

public class GetProjectPhaseListQueryHandler : ResponseHandler, IRequestHandler<GetProjectPhaseListQuery, Response<List<GetProjectPhaseListResponse>>>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectPhaseListQueryHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectPhaseListResponse>>> Handle(GetProjectPhaseListQuery request, CancellationToken cancellationToken)
    {
        var projectPhaseListDB = await _projectPhaseManager.GetProjectPhasesListAsync().Include(x => x.Project).ToListAsync();
        if (projectPhaseListDB is null)
        {
            return NotFound<List<GetProjectPhaseListResponse>>();
        }
        var projectPhaseListMapper = _mapper.Map<List<GetProjectPhaseListResponse>>(projectPhaseListDB);
        return Success(projectPhaseListMapper);
    }
    #endregion

}