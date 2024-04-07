using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Companies;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Companies.Commands.Handlers;

public class DeleteCompanyCommandHandler : ResponseHandler, IRequestHandler<DeleteCompanyCommand, Response<string>>
{

    #region Fields
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteCompanyCommandHandler(ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.ID);
        if (company == null) return NotFound<string>("");
        if (await _companyManager.DeleteCompanyAsync(company))
            return Deleted<string>("");
        return BadRequest<string>();


    }
    #endregion
}
