﻿using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Core.Resources;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Products;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Products.Commands.Handlers;

public class UpdateProductCommandHandler : ResponseHandler, IRequestHandler<UpdateProductCommand, Response<string>>
{

    #region Fields
    private readonly IProductManager _productManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateProductCommandHandler(IProductManager productManager, ICompanyManager companyManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetByIdAsync(request.CompanyId);
        if (company != null)
        {
            var product = _mapper.Map<Product>(request);

            if (await _productManager.UpdateAsync(product))
                return Created("");
            return BadRequest<string>("");
        }
        return NotFound<string>("");
    }

    #endregion
}
