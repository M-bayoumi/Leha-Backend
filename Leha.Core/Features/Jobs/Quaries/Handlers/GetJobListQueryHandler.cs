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

public class GetJobListQueryHandler : ResponseHandler, IRequestHandler<GetJobListQuery, Response<List<GetJobListResponse>>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobListQueryHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetJobListResponse>>> Handle(GetJobListQuery request, CancellationToken cancellationToken)
    {
        var jobListDB = await _jobManager.GetJobsListAsync().Include(x => x.Company).ToListAsync();
        if (jobListDB is null)
        {
            return NotFound<List<GetJobListResponse>>();
        }
        var jobListMapper = _mapper.Map<List<GetJobListResponse>>(jobListDB);
        return Success(jobListMapper);
    }
    #endregion

}