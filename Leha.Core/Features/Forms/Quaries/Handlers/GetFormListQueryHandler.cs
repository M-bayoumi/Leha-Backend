using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Models;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Forms.Quaries.Handlers;

public class GetFormListQueryHandler : ResponseHandler, IRequestHandler<GetFormListQuery, Response<List<GetFormListResponse>>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormListQueryHandler(IFormManager formManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetFormListResponse>>> Handle(GetFormListQuery request, CancellationToken cancellationToken)
    {
        var formListDB = await _formManager.GetFormsListAsync().Include(x => x.Job).ToListAsync();
        if (formListDB is null)
        {
            return NotFound<List<GetFormListResponse>>();
        }
        var formListMapper = _mapper.Map<List<GetFormListResponse>>(formListDB);
        return Success(formListMapper);
    }
    #endregion

}