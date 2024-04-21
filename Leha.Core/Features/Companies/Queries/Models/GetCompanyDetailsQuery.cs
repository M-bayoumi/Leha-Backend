using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Results;
using MediatR;

namespace Leha.Core.Features.Companies.Queries.Models;

public class GetCompanyDetailsQuery : IRequest<Response<GetCompanyDetailsResponse>>
{
    public int Id { get; set; }

    public GetCompanyDetailsQuery(int companyID)
    {
        Id = companyID;
    }
    public GetCompanyDetailsQuery()
    {
    }
}

