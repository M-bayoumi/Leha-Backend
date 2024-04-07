using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Models;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.ProjectPhases.Quaries.Handlers;

public class GetProjectPhaseListByProjectIdQueryHandler : ResponseHandler, IRequestHandler<GetProjectPhaseListByProjectIdQuery, Response<List<GetProjectPhaseListByProjectIDResponse>>>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectPhaseListByProjectIdQueryHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectPhaseListByProjectIDResponse>>> Handle(GetProjectPhaseListByProjectIdQuery request, CancellationToken cancellationToken)
    {
        var projectPhaseListDB = await _projectPhaseManager.GetProjectPhasesListByProjectId(request.ID).Include(x => x.Project).ToListAsync();
        if (projectPhaseListDB is null)
        {
            return NotFound<List<GetProjectPhaseListByProjectIDResponse>>();
        }
        var projectPhaseListMapper = _mapper.Map<List<GetProjectPhaseListByProjectIDResponse>>(projectPhaseListDB);
        return Success(projectPhaseListMapper);
    }
    #endregion

}
