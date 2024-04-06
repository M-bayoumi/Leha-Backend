using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Models;
using Leha.Core.Features.Products.Quaries.Results;
using Leha.Manager.Managers.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Leha.Core.Features.Products.Quaries.Handlers;

public class GetProductListByCompanyIdQueryHandler : ResponseHandler, IRequestHandler<GetProductListByCompanyIdQuery, Response<List<GetProductListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProductListByCompanyIdQueryHandler(IProductManager productManager, IMapper mapper)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProductListByCompanyIDResponse>>> Handle(GetProductListByCompanyIdQuery request, CancellationToken cancellationToken)
    {
        var productListDB = await _productManager.GetProductsListByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (productListDB is null)
        {
            return NotFound<List<GetProductListByCompanyIDResponse>>();
        }
        var productListMapper = _mapper.Map<List<GetProductListByCompanyIDResponse>>(productListDB);
        return Success(productListMapper);
    }
    #endregion

}
