using Leha.Core.BaseResponse;
using Leha.Core.Features.CompanyAddresses.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Quaries.Models;

public class GetCompanyAddressByIDQuery : IRequest<Response<GetCompanyAddressByIDResponse>>
{
    public int ID { get; set; }

    public GetCompanyAddressByIDQuery(int clientID)
    {
        ID = clientID;
    }
    public GetCompanyAddressByIDQuery()
    {
    }
}
