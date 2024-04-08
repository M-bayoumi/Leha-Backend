using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductListByCompanyIDQuery : IRequest<Response<List<GetProductListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetProductListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetProductListByCompanyIDQuery()
    {
    }
}
