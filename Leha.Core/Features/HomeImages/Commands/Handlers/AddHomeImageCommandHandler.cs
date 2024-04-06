using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.HomeImages;
using MediatR;

namespace Leha.Core.Features.HomeImages.Commands.Handlers;


public class AddHomeImageCommandHandler : ResponseHandler, IRequestHandler<AddHomeImageCommand, Response<string>>
{

    #region Fields
    private readonly IHomeImageManager _homeImageManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddHomeImageCommandHandler(IHomeImageManager homeImageManager, ICompanyManager companyManager, IMapper mapper)
    {
        _homeImageManager = homeImageManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion


    #region Handle Functions
    public async Task<Response<string>> Handle(AddHomeImageCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var homeImage = _mapper.Map<HomeImage>(request);

            if (await _homeImageManager.AddHomeImageAsync(homeImage))
                return Created("HomeImage Added Successfully");
            return BadRequest<string>("Failed To Add HomeImage");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
