using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Models;
using Leha.Core.Features.Projects.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Projects;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Projects.Quaries.Handlers;

public class GetProjectListQueryHandler : ResponseHandler, IRequestHandler<GetProjectListQuery, Response<List<GetProjectListResponse>>>
{
    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectListQueryHandler(IProjectManager projectManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectListResponse>>> Handle(GetProjectListQuery request, CancellationToken cancellationToken)
    {
        var projectListDB = await _projectManager.GetAll().Include(x => x.Company).ToListAsync();
        if (projectListDB is null)
        {
            return NotFound<List<GetProjectListResponse>>();
        }
        var projectListMapper = _mapper.Map<List<GetProjectListResponse>>(projectListDB);
        return Success(projectListMapper);
    }
    #endregion

}