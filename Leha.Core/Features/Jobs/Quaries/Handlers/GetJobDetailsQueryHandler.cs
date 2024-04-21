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

public class GetJobDetailsQueryHandler : ResponseHandler, IRequestHandler<GetJobDetailsQuery, Response<GetJobDetailsResponse>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobDetailsQueryHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetJobDetailsResponse>> Handle(GetJobDetailsQuery request, CancellationToken cancellationToken)
    {
        var jobDB = await _jobManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (jobDB is null)
        {
            return NotFound<GetJobDetailsResponse>();
        }
        var jobMapper = _mapper.Map<GetJobDetailsResponse>(jobDB);
        return Success(jobMapper);
    }
    #endregion

}
