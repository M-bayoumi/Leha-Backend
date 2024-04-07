using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Jobs.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Jobs.Commands.Handlers;

public class DeleteJobCommandHandler : ResponseHandler, IRequestHandler<DeleteJobCommand, Response<string>>
{

    #region Fields
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteJobCommandHandler(IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteJobCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobManager.GetJobByIDAsync(request.ID);
        if (job == null) return NotFound<string>("");
        if (await _jobManager.DeleteJobAsync(job))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}