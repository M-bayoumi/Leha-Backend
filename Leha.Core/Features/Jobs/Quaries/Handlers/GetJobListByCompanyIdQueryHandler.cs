using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Quaries.Models;
using Leha.Core.Features.Jobs.Quaries.Results;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Jobs.Quaries.Handlers;

public class GetJobListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetJobListByCompanyIdQuery, Response<List<GetJobListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobListByCompanyIdQueryHandler(IJobManager jobManager, IMapper mapper)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetJobListByCompanyIDResponse>>> Handle(GetJobListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var jobListDB = await _jobManager.GetJobsListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (jobListDB is null)
        {
            return NotFound<List<GetJobListByCompanyIDResponse>>();
        }
        var jobListMapper = _mapper.Map<List<GetJobListByCompanyIDResponse>>(jobListDB);
        return Success(jobListMapper);
    }
    #endregion

}
