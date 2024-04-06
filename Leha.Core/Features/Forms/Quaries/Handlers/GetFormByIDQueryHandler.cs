using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Models;
using Leha.Core.Features.Forms.Quaries.Results;
using Leha.Manager.Managers.Forms;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Forms.Quaries.Handlers;


public class GetFormByIDQueryHandler : ResponseHandler, IRequestHandler<GetFormByIDQuery, Response<GetFormByIDResponse>>
{
    #region Fields
    private readonly IFormManager _formManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetFormByIDQueryHandler(IFormManager formManager, IMapper mapper)
    {
        _formManager = formManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetFormByIDResponse>> Handle(GetFormByIDQuery request, CancellationToken cancellationToken)
    {
        var formDB = await _formManager.GetFormsListAsync().Include(x => x.Job).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (formDB is null)
        {
            return NotFound<GetFormByIDResponse>();
        }
        var formMapper = _mapper.Map<GetFormByIDResponse>(formDB);
        return Success(formMapper);
    }
    #endregion

}
