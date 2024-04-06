using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Models;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Manager.Managers.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Forms.Quaries.Handlers;

public class GetFormListByJobIdQueryHandler : ResponseHandler, IRequestHandler<GetFormListByJobIdQuery, Response<List<GetFormListByJobIDResponse>>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormListByJobIdQueryHandler(IFormManager formManager, IMapper mapper)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetFormListByJobIDResponse>>> Handle(GetFormListByJobIdQuery request, CancellationToken cancellationToken)
    {
        var formListDB = await _formManager.GetFormsListByJobId(request.ID).Include(x => x.Job).ToListAsync();
        if (formListDB is null)
        {
            return NotFound<List<GetFormListByJobIDResponse>>();
        }
        var formListMapper = _mapper.Map<List<GetFormListByJobIDResponse>>(formListDB);
        return Success(formListMapper);
    }
    #endregion

}
