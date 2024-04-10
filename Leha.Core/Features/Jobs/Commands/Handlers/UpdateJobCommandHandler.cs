using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Jobs.Commands.Handlers;

public class UpdateJobCommandHandler : ResponseHandler, IRequestHandler<UpdateJobCommand, Response<string>>
{

    #region Fields
    private readonly IJobManager _jobManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateJobCommandHandler(IJobManager jobManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateJobCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetByIdAsync(request.CompanyId);
        if (company != null)
        {
            var job = _mapper.Map<Job>(request);

            if (await _jobManager.UpdateAsync(job))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
