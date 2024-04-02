using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class AddCompanyCommandHandler : ResponseHandler, IRequestHandler<AddCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyService;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AddCompanyCommandHandler(ICompanyManager companyService, IMapper mapper)
    {
        _companyService = companyService;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(request);

        return await _companyService.AddCompanyAsync(company) ? Created("Added Successfully") : BadRequest<string>();
    }

    #endregion
}
