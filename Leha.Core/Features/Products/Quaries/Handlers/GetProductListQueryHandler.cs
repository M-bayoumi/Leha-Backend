using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Models;
using Leha.Core.Features.Products.Quaries.Results;
using Leha.Core.Resources;
using Leha.Manager.Managers.Products;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Products.Quaries.Handlers;

public class GetProductListQueryHandler : ResponseHandler, IRequestHandler<GetProductListQuery, Response<List<GetProductListResponse>>>
{
    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProductListQueryHandler(IProductManager productManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProductListResponse>>> Handle(GetProductListQuery request, CancellationToken cancellationToken)
    {
        var productListDB = await _productManager.GetProductsListAsync().Include(x => x.Company).ToListAsync();
        if (productListDB is null)
        {
            return NotFound<List<GetProductListResponse>>();
        }
        var productListMapper = _mapper.Map<List<GetProductListResponse>>(productListDB);
        return Success(productListMapper);
    }
    #endregion

}