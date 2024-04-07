using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class AddCompanyCommandHandler : ResponseHandler, IRequestHandler<AddCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public AddCompanyCommandHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = _mapper.Map<Company>(request);

        if (await _companyManager.AddCompanyAsync(company))
            return Created("");
        return BadRequest<string>("");
    }

    #endregion
}
