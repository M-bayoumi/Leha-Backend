using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductByIdQuery : IRequest<Response<GetProductByIdResponse>>
{
    public int ID { get; set; }

    public GetProductByIdQuery(int productID)
    {
        ID = productID;
    }
    public GetProductByIdQuery()
    {
    }
}
