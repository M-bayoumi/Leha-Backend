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

public class GetFormListByJobIDQueryHandler : ResponseHandler, IRequestHandler<GetFormListByJobIDQuery, Response<List<GetFormListByJobIDResponse>>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormListByJobIDQueryHandler(IFormManager formManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetFormListByJobIDResponse>>> Handle(GetFormListByJobIDQuery request, CancellationToken cancellationToken)
    {
        var formListDB = await _formManager.GetAllByJobId(request.Id).Include(x => x.Job).ToListAsync();
        if (formListDB is null)
        {
            return NotFound<List<GetFormListByJobIDResponse>>();
        }
        var formListMapper = _mapper.Map<List<GetFormListByJobIDResponse>>(formListDB);
        return Success(formListMapper);
    }
    #endregion

}
