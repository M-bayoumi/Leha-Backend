using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Data.Entities;
using Leha.Manager.Managers.Companies;
using Leha.Manager.Managers.Products;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Handlers;


public class AddProductCommandHandler : ResponseHandler, IRequestHandler<AddProductCommand, Response<string>>
{

    #region Fields
    private readonly IProductManager _productManager;
    private readonly ICompanyManager _companyManager;
    private readonly IMapper _mapper;

    #endregion

    #region Constructors

    public AddProductCommandHandler(IProductManager productManager, ICompanyManager companyManager, IMapper mapper)
    {
        _productManager = productManager;
        _companyManager = companyManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var company = await _companyManager.GetCompanyByIDAsync(request.CompanyID); // GetById without without include 
        if (company != null)
        {
            var product = _mapper.Map<Product>(request);

            if (await _productManager.AddProductAsync(product))
                return Created("Product Added Successfully");
            return BadRequest<string>("Failed To Add Product");
        }
        return NotFound<string>("Company not found");
    }

    #endregion
}
