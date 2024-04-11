using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int productID)
    {
        Id = productID;
    }
    public GetProductByIdQuery()
    {
    }
}
