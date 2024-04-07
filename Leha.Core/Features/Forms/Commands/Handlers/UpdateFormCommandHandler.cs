﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Forms;
using Leha.Manager.Managers.Jobs;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Forms.Commands.Handlers;

public class UpdateFormCommandHandler : ResponseHandler, IRequestHandler<UpdateFormCommand, Response<string>>
{

    #region Fields
    private readonly IFormManager _formManager;
    private readonly IJobManager _jobManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateFormCommandHandler(IFormManager formManager, IJobManager jobManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _jobManager = jobManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateFormCommand request, CancellationToken cancellationToken)
    {
        var job = await _jobManager.GetJobByIDAsync(request.JobID);
        if (job != null)
        {
            var form = _mapper.Map<Form>(request);

            if (await _formManager.UpdateFormAsync(form))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
