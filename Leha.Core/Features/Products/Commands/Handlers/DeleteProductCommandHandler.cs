using AutoMapper;
using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Commands.Models;
using Leha.Manager.Managers.Products;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Handlers;

public class DeleteProductCommandHandler : ResponseHandler, IRequestHandler<DeleteProductCommand, Response<string>>
{

    #region Fields
    private readonly IProductManager _productManager;
    private readonly IMapper _mapper;
    #endregion

    #region Constructors
    public DeleteProductCommandHandler(IProductManager productManager, IMapper mapper)
    {
        _productManager = productManager;
        _mapper = mapper;
    }
    #endregion

    #region Handle Functions
    public async Task<Response<string>> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productManager.GetProductByIDAsync(request.ID);
        if (product == null) return NotFound<string>("Product not found");
        return await _productManager.DeleteProductAsync(product) ? Deleted<string>("Deleted Successfully") : BadRequest<string>();
    }

    #endregion
}