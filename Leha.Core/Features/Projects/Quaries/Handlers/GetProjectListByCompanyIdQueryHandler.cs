using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Models;
using Leha.Core.Features.Projects.Quaries.Results;
using Leha.Manager.Managers.Projects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Projects.Quaries.Handlers;

public class GetProjectListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetProjectListByCompanyIdQuery, Response<List<GetProjectListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectListByCompanyIdQueryHandler(IProjectManager projectManager, IMapper mapper)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProjectListByCompanyIDResponse>>> Handle(GetProjectListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var projectListDB = await _projectManager.GetProjectsListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (projectListDB is null)
        {
            return NotFound<List<GetProjectListByCompanyIDResponse>>();
        }
        var projectListMapper = _mapper.Map<List<GetProjectListByCompanyIDResponse>>(projectListDB);
        return Success(projectListMapper);
    }
    #endregion

}
