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

public class GetProjectDetailsQueryHandler : ResponseHandler, IRequestHandler<GetProjectDetailsQuery, Response<GetProjectDetailsResponse>>
{
    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectDetailsQueryHandler(IProjectManager projectManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProjectDetailsResponse>> Handle(GetProjectDetailsQuery request, CancellationToken cancellationToken)
    {
        var projectDB = await _projectManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (projectDB is null)
        {
            return NotFound<GetProjectDetailsResponse>();
        }
        var projectMapper = _mapper.Map<GetProjectDetailsResponse>(projectDB);
        return Success(projectMapper);
    }
    #endregion

}

