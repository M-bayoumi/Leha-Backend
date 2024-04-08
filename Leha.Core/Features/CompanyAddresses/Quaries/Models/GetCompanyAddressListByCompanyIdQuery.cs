using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressListByCompanyIDQuery : IRequest<Response<List<GetCompanyAddressListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetCompanyAddressListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetCompanyAddressListByCompanyIDQuery()
    {
    }
}
