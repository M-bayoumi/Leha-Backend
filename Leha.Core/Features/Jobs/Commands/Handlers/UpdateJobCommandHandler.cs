using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Jobs;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Handlers;

public class UpdateJobCommandHandler : ResponseHandler, IRequestHandler<UpdateJobCommand, Response<string>>
{

    #region Fields
    private readonly IJobManager _jobManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateJobCommandHandler(IJobManager jobManager, ICompanyManager companyManager, IMapper mapper)
    {
        _jobManager = jobManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var job = _mapper.Map<Job>(request);

            if (await _jobManager.UpdateJobAsync(job))
                return Created("Job Updated Successfully");
            return BadRequest<string>("Failed To Update Job");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
