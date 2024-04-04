using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class UpdateCompanyCommandHandler : ResponseHandler, IRequestHandler<UpdateCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public UpdateCompanyCommandHandler(ICompanyManager companyManager, IMapper mapper)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
    {
        var companyDB = await _companyManager.GetCompanyByIDAsync(request.ID);
        if (companyDB == null) return NotFound<string>("Company not found");
        var company = _mapper.Map<Company>(request);
        return await _companyManager.UpdateCompanyAsync(company) ? Created("Updated Successfully") : BadRequest<string>();
    }
    #endregion
}
