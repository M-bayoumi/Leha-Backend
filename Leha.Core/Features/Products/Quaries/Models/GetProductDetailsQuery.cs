using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductDetailsQuery : IRequest<Response<GetProductDetailsResponse>>
{
    public int Id { get; set; }

    public GetProductDetailsQuery(int productID)
    {
        Id = productID;
    }
    public GetProductDetailsQuery()
    {
    }
}
