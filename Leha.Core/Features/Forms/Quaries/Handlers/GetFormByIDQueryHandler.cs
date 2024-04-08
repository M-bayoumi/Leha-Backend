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


public class GetFormByIdQueryHandler : ResponseHandler, IRequestHandler<GetFormByIdQuery, Response<GetFormByIdResponse>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormByIdQueryHandler(IFormManager formManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetFormByIdResponse>> Handle(GetFormByIdQuery request, CancellationToken cancellationToken)
    {
        var formDB = await _formManager.GetAll().Include(x => x.Job).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (formDB is null)
        {
            return NotFound<GetFormByIdResponse>();
        }
        var formMapper = _mapper.Map<GetFormByIdResponse>(formDB);
        return Success(formMapper);
    }
    #endregion

}
