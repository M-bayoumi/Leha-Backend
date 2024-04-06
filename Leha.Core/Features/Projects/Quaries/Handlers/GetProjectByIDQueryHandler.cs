using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Models;
using Leha.Core.Features.Projects.Quaries.Results;
using Leha.Manager.Managers.Projects;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Projects.Quaries.Handlers;


public class GetProjectByIDQueryHandler : ResponseHandler, IRequestHandler<GetProjectByIDQuery, Response<GetProjectByIDResponse>>
{
    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectByIDQueryHandler(IProjectManager projectManager, IMapper mapper)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProjectByIDResponse>> Handle(GetProjectByIDQuery request, CancellationToken cancellationToken)
    {
        var projectDB = await _projectManager.GetProjectsListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (projectDB is null)
        {
            return NotFound<GetProjectByIDResponse>();
        }
        var projectMapper = _mapper.Map<GetProjectByIDResponse>(projectDB);
        return Success(projectMapper);
    }
    #endregion

}
