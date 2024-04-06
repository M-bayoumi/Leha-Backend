using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Manager.Managers.Jobs;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Handlers;

public class DeleteJobCommandHandler : ResponseHandler, IRequestHandler<DeleteJobCommand, Response<string>>
{

    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteJobCommandHandler(IJobManager jobManager, IMapper mapper)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobManager.GetJobByIDAsync(request.ID);
        if (job == null) return NotFound<string>("Job not found");
        return await _jobManager.DeleteJobAsync(job) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}