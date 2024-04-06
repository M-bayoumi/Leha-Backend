using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressListByCompanyIdQuery : IRequest<Response<List<GetCompanyAddressListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetCompanyAddressListByCompanyIdQuery(int companyID)
    {
        ID = companyID;
    }
    public GetCompanyAddressListByCompanyIdQuery()
    {
    }
}
