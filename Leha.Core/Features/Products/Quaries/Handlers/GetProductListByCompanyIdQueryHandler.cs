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

public class GetProductListByCompanyIDQueryHandler : ResponseHandler, IRequestHandler<GetProductListByCompanyIDQuery, Response<List<GetProductListByCompanyIDResponse>>>
{
    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProductListByCompanyIDQueryHandler(IProductManager productManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<List<GetProductListByCompanyIDResponse>>> Handle(GetProductListByCompanyIDQuery request, CancellationToken cancellationToken)
    {
        var productListDB = await _productManager.GetAllByCompanyId(request.ID).Include(x => x.Company).ToListAsync();
        if (productListDB is null)
        {
            return NotFound<List<GetProductListByCompanyIDResponse>>();
        }
        var productListMapper = _mapper.Map<List<GetProductListByCompanyIDResponse>>(productListDB);
        return Success(productListMapper);
    }
    #endregion

}
