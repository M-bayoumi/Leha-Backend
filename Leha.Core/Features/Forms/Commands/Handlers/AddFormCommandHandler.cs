using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Forms;
using Leha.Manager.Managers.Jobs;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Handlers;


public class AddFormCommandHandler : ResponseHandler, IRequestHandler<AddFormCommand, Response<string>>
{

    #region Fields
    private readonly IFormManager _formManager;
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddFormCommandHandler(IFormManager formManager, IJobManager jobManager, IMapper mapper)
    {
        _formManager = formManager;
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddFormCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobManager.GetJobByIDAsync(request.JobID); // GetById without without include 
        if (job != null)
        {
            var form = _mapper.Map<Form>(request);

            if (await _formManager.AddFormAsync(form))
                return Created("Form Added Successfully");
            return BadRequest<string>("Failed To Add Form");
        }
        return NotFound<string>("Job not found");
    }

    #endregion
}
