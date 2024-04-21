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

public class GetFormDetailsQueryHandler : ResponseHandler, IRequestHandler<GetFormDetailsQuery, Response<GetFormDetailsResponse>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormDetailsQueryHandler(IFormManager formManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetFormDetailsResponse>> Handle(GetFormDetailsQuery request, CancellationToken cancellationToken)
    {
        var formDB = await _formManager.GetAll().Include(x => x.Job).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (formDB is null)
        {
            return NotFound<GetFormDetailsResponse>();
        }
        var formMapper = _mapper.Map<GetFormDetailsResponse>(formDB);
        return Success(formMapper);
    }
    #endregion

}