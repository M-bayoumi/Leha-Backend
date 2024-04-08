using Leha.Core.BaseResponse;
using Leha.Core.Features.Projects.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Projects.Quaries.Models;

public class GetProjectListByCompanyIDQuery : IRequest<Response<List<GetProjectListByCompanyIDResponse>>>
{
    public int ID { get; set; }

    public GetProjectListByCompanyIDQuery(int companyID)
    {
        ID = companyID;
    }
    public GetProjectListByCompanyIDQuery()
    {
    }
}
