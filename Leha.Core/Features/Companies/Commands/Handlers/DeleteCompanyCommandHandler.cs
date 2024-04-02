using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class DeleteCompanyCommandHandler : ResponseHandler, IRequestHandler<DeleteCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteCompanyCommandHandler(ICompanyManager companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyService.GetCompanyByIDAsync(request.ID); // GetById without without include 
        if (company == null) return NotFound<string>("Company not found");
        return await _companyService.DeleteCompanyAsync(company) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();


    }
    #endregion
}
