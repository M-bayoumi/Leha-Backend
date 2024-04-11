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

public class GetProjectListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetProjectListByCompanyIDQuery, Response<List<GetProjectListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectListByCompanyIDQueryHandler(IProjectManager projectManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectListByCompanyIDResponse>>> Handle(GetProjectListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var projectListDB = await _projectManager.GetAllByCompanyId(request.Id).Include(x => x.Company).ToListAsync();
        if (projectListDB is null)
        {
            return NotFound<List<GetProjectListByCompanyIDResponse>>();
        }
        var projectListMapper = _mapper.Map<List<GetProjectListByCompanyIDResponse>>(projectListDB);
        return Success(projectListMapper);
    }
    #endregion

}
