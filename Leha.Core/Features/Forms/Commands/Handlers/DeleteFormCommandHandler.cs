using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Commands.Models;
using Leha.Manager.Managers.Forms;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Handlers;

public class DeleteFormCommandHandler : ResponseHandler, IRequestHandler<DeleteFormCommand, Response<string>>
{

    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteFormCommandHandler(IFormManager formManager, IMapper mapper)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteFormCommand request, CancellationToken cancellationToken)
    {
        var form = await _formManager.GetFormByIDAsync(request.ID);
        if (form == null) return NotFound<string>("Form not found");
        return await _formManager.DeleteFormAsync(form) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}