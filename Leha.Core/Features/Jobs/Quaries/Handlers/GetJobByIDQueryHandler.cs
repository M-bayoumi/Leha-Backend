using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Models;
using Leha.Core.Features.Jobs.Quaries.Models;
using Leha.Core.Features.Jobs.Quaries.Results;
using Leha.Manager.Managers.BoardMemberSpeeches;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leha.Core.Features.Jobs.Quaries.Handlers;


public class GetJobByIDQueryHandler : ResponseHandler, IRequestHandler<GetJobByIDQuery, Response<GetJobByIDResponse>>
{
    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetJobByIDQueryHandler(IJobManager jobManager, IMapper mapper)
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
