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


public class GetProductByIDQueryHandler : ResponseHandler, IRequestHandler<GetProductByIDQuery, Response<GetProductByIDResponse>>
{
    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProductByIDQueryHandler(IProductManager productManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProductByIDResponse>> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
    {
        var productDB = await _productManager.GetProductsListAsync().Include(x => x.Company).FirstOrDefaultAsync(x => x.ID == request.ID);

        if (productDB is null)
        {
            return NotFound<GetProductByIDResponse>();
        }
        var productMapper = _mapper.Map<GetProductByIDResponse>(productDB);
        return Success(productMapper);
    }
    #endregion

}
