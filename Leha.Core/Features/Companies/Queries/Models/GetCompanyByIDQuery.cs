using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Results;
using MediatR;

namespace Leha.Core.Features.Companies.Queries.Models;

public class GetCompanyByIDQuery : IRequest<Response<GetCompanyByIDResponse>>
{
    public int ID { get; set; }

    public GetCompanyByIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetCompanyByIDQuery()
    {
    }
}

