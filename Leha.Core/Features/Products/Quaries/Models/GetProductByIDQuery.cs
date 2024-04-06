using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductByIDQuery : IRequest<Response<GetProductByIDResponse>>
{
    public int ID { get; set; }

    public GetProductByIDQuery(int productID)
    {
        ID = productID;
    }
    public GetProductByIDQuery()
    {
    }
}
