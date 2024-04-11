using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Core.Resources;
using Leha.Manager.Managers.Products;
using MediatR;
using Microsoft.Extensions.Localization;

namespace Leha.Core.Features.Products.Commands.Handlers;

public class DeleteProductCommandHandler : ResponseHandler, IRequestHandler<DeleteProductCommand, Response<string>>
{

    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProductCommandHandler(IProductManager productManager, IMapper mapper, IStringLocalizer<SharedResources> localizer) : base(localizer)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productManager.GetByIdAsync(request.Id);
        if (product == null) return NotFound<string>("");
        if (await _productManager.DeleteAsync(product))
            return Deleted<string>("");
        return BadRequest<string>();
    }

    #endregion
}