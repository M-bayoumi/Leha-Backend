using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Jobs;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Handlers;


public class AddJobCommandHandler : ResponseHandler, IRequestHandler<AddJobCommand, Response<string>>
{

    #region Fields
    private readonly IJobManager _jobManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddJobCommandHandler(IJobManager jobManager, ICompanyManager companyManager, IMapper mapper)
    {
        _jobManager = jobManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddJobCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var job = _mapper.Map<Job>(request);

            if (await _jobManager.AddJobAsync(job))
                return Created("Job Added Successfully");
            return BadRequest<string>("Failed To Add Job");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
