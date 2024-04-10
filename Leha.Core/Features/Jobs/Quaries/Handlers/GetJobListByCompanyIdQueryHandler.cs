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

public class GetJobListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetJobListByCompanyIDQuery, Response<List<GetJobListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobListByCompanyIDQueryHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetJobListByCompanyIDResponse>>> Handle(GetJobListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var jobListDB = await _jobManager.GetAllByCompanyId(request.Id).Include(x => x.Company).ToListAsync();
        if (jobListDB is null)
        {
            return NotFound<List<GetJobListByCompanyIDResponse>>();
        }
        var jobListMapper = _mapper.Map<List<GetJobListByCompanyIDResponse>>(jobListDB);
        return Success(jobListMapper);
    }
    #endregion

}
