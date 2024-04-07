using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Models;
using Leha.Core.Features.Jobs.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Jobs.Quaries.Handlers;


public class GetJobByIDQueryHandler : ResponseHandler, IRequestHandler<GetJobByIDQuery, Response<GetJobByIDResponse>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobByIDQueryHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetJobByIDResponse>> Handle(GetJobByIDQuery request, CancellationToken cancellationToken)
    {
        var jobDB = await _jobManager.GetJobsListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (jobDB is null)
        {
            return NotFound<GetJobByIDResponse>();
        }
        var jobMapper = _mapper.Map<GetJobByIDResponse>(jobDB);
        return Success(jobMapper);
    }
    #endregion

}
