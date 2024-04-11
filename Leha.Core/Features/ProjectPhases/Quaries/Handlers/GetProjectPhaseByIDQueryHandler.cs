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


public class GetProjectPhaseByIdQueryHandler : ResponseHandler, IRequestHandler<GetProjectPhaseByIdQuery, Response<GetProjectPhaseByIdResponse>>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectPhaseByIdQueryHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProjectPhaseByIdResponse>> Handle(GetProjectPhaseByIdQuery request, CancellationToken cancellationToken)
    {
        var projectPhaseDB = await _projectPhaseManager.GetAll().Include(x => x.Project).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (projectPhaseDB is null)
        {
            return NotFound<GetProjectPhaseByIdResponse>();
        }
        var projectPhaseMapper = _mapper.Map<GetProjectPhaseByIdResponse>(projectPhaseDB);
        return Success(projectPhaseMapper);
    }
    #endregion

}
