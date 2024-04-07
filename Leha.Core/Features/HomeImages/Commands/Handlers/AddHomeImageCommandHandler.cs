using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.HomeImages;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.HomeImages.Commands.Handlers;


public class AddHomeImageCommandHandler : ResponseHandler, IRequestHandler<AddHomeImageCommand, Response<string>>
{

    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddHomeImageCommandHandler(IHomeImageManager homeImageManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _homeImageManager = homeImageManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion


    #region Handle Functions
    public async Task<Response<string>> Handle(AddHomeImageCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID);
        if (company != null)
        {
            var homeImage = _mapper.Map<HomeImage>(request);

            if (await _homeImageManager.AddHomeImageAsync(homeImage))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
