using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Forms;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Forms.Commands.Handlers;

public class DeleteFormCommandHandler : ResponseHandler, IRequestHandler<DeleteFormCommand, Response<string>>
{

    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteFormCommandHandler(IFormManager formManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _formManager.GetFormByIDAsync(request.ID);
        if (form == null) return NotFound<string>("");
        if (await _formManager.DeleteFormAsync(form))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}