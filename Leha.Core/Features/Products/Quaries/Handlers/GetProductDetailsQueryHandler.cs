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

public class GetProductDetailsQueryHandler : ResponseHandler, IRequestHandler<GetProductDetailsQuery, Response<GetProductDetailsResponse>>
{
    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public GetProductDetailsQueryHandler(IProductManager productManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<GetProductDetailsResponse>> Handle(GetProductDetailsQuery request, CancellationToken cancellationToken)
    {
        var productDB = await _productManager.GetAll().Include(x => x.Company).FirstOrDefaultAsync(x => x.Id == request.Id);

        if (productDB is null)
        {
            return NotFound<GetProductDetailsResponse>();
        }
        var productMapper = _mapper.Map<GetProductDetailsResponse>(productDB);
        return Success(productMapper);
    }
    #endregion

}
