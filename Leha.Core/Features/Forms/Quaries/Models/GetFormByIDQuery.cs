using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormByIdQuery : IRequest<Response<GetFormByIdResponse>>
{
    public int ID { get; set; }

    public GetFormByIdQuery(int formID)
    {
        ID = formID;
    }
    public GetFormByIdQuery()
    {
    }
}
