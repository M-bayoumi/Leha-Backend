using Leha.Core.BaseResponse;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductListByCompanyIdQuery : IRequest<Response<List<GetProductListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetProductListByCompanyIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetProductListByCompanyIdQuery()
    {
    }
}
