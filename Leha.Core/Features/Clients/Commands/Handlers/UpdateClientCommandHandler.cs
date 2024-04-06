using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Clients.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Clients;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Clients.Commands.Handlers;

public class UpdateClientCommandHandler : ResponseHandler, IRequestHandler<UpdateClientCommand, Response<string>>
{

    #region Fields
    private readonly IClientManager _clientManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateClientCommandHandler(IClientManager clientManager, ICompanyManager companyManager, IMapper mapper)
    {
        _clientManager = clientManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var client = _mapper.Map<Client>(request);

            if (await _clientManager.UpdateClientAsync(client))
                return Created("Client Updated Successfully");
            return BadRequest<string>("Failed To Update Client");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
