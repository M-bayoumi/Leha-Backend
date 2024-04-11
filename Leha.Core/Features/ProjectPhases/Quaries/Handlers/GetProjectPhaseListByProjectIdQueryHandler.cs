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

public class GetProjectPhaseListByProjectIDQueryHandler : ResponseHandler, IRequestHandler<GetProjectPhaseListByProjectIDQuery, Response<List<GetProjectPhaseListByProjectIDResponse>>>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectPhaseListByProjectIDQueryHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectPhaseListByProjectIDResponse>>> Handle(GetProjectPhaseListByProjectIDQuery request, CancellationToken cancellationToken)
    {
        var projectPhaseListDB = await _projectPhaseManager.GetAllByProjectID(request.Id).Include(x => x.Project).ToListAsync();
        if (projectPhaseListDB is null)
        {
            return NotFound<List<GetProjectPhaseListByProjectIDResponse>>();
        }
        var projectPhaseListMapper = _mapper.Map<List<GetProjectPhaseListByProjectIDResponse>>(projectPhaseListDB);
        return Success(projectPhaseListMapper);
    }
    #endregion

}
