using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Products;
using Leha.Manager.Managers.Companies;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Handlers;

public class UpdateProductCommandHandler : ResponseHandler, IRequestHandler<UpdateProductCommand, Response<string>>
{

    #region Fields
    private readonly IProductManager _productManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public UpdateProductCommandHandler(IProductManager productManager, ICompanyManager companyManager, IMapper mapper)
    {
        _productManager = productManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var product = _mapper.Map<Product>(request);

            if (await _productManager.UpdateProductAsync(product))
                return Created("Product Updated Successfully");
            return BadRequest<string>("Failed To Update Product");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
