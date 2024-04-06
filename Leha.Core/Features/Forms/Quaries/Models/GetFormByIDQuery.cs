using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormByIDQuery : IRequest<Response<GetFormByIDResponse>>
{
    public int ID { get; set; }

    public GetFormByIDQuery(int formID)
    {
        ID = formID;
    }
    public GetFormByIDQuery()
    {
    }
}
