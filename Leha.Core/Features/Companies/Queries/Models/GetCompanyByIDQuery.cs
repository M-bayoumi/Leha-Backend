using Leha.Core.BaseResponse;
using Leha.Core.Features.Companies.Queries.Results;
using MediatR;

namespace Leha.Core.Features.Companies.Queries.Models;

public class GetCompanyByIdQuery : IRequest<Response<GetCompanyByIdResponse>>
{
    public int Id { get; set; }

    public GetCompanyByIdQuery(int companyID)
    {
        Id = companyID;
    }
    public GetCompanyByIdQuery()
    {
    }
}

