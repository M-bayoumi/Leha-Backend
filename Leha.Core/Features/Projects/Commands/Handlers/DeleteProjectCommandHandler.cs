using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Projects;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Projects.Commands.Handlers;

public class DeleteProjectCommandHandler : ResponseHandler, IRequestHandler<DeleteProjectCommand, Response<string>>
{

    #region Fields
    private readonly IProjectManager _projectManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProjectCommandHandler(IProjectManager projectManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _projectManager = projectManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProjectCommand request, CancellationToken cancellationToken)
    {
        var project = await _projectManager.GetByIdAsync(request.Id);
        if (project == null) return NotFound<string>("");
        if (await _projectManager.DeleteAsync(project))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}