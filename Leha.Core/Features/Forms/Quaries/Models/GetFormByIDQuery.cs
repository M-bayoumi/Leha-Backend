using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormByIdQuery : IRequest<Response<GetFormByIdResponse>>
{
    public int Id { get; set; }

    public GetFormByIdQuery(int formID)
    {
        Id = formID;
    }
    public GetFormByIdQuery()
    {
    }
}
