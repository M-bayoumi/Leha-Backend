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


public class GetJobByIdQueryHandler : ResponseHandler, IRequestHandler<GetJobByIdQuery, Response<GetJobByIdResponse>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobByIdQueryHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetJobByIdResponse>> Handle(GetJobByIdQuery request, CancellationToken cancellationToken)
    {
        var jobDB = await _jobManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (jobDB is null)
        {
            return NotFound<GetJobByIdResponse>();
        }
        var jobMapper = _mapper.Map<GetJobByIdResponse>(jobDB);
        return Success(jobMapper);
    }
    #endregion

}
