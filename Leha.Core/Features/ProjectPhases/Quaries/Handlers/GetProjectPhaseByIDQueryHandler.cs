using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.ProjectPhases.Quaries.Models;
using Leha.Core.Features.ProjectPhases.Quaries.Results;
using Leha.Manager.Managers.ProjectPhases;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.ProjectPhases.Quaries.Handlers;


public class GetProjectPhaseByIDQueryHandler : ResponseHandler, IRequestHandler<GetProjectPhaseByIDQuery, Response<GetProjectPhaseByIDResponse>>
{
    #region Fields
    private readonly IProjectPhaseManager _projectPhaseManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProjectPhaseByIDQueryHandler(IProjectPhaseManager projectPhaseManager, IMapper mapper)
    {
        _projectPhaseManager = projectPhaseManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProjectPhaseByIDResponse>> Handle(GetProjectPhaseByIDQuery request, CancellationToken cancellationToken)
    {
        var projectPhaseDB = await _projectPhaseManager.GetProjectPhasesListAsync().Include(x => x.Project).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (projectPhaseDB is null)
        {
            return NotFound<GetProjectPhaseByIDResponse>();
        }
        var projectPhaseMapper = _mapper.Map<GetProjectPhaseByIDResponse>(projectPhaseDB);
        return Success(projectPhaseMapper);
    }
    #endregion

}
