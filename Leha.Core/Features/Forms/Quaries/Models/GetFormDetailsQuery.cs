using Leha.Core.BaseResponse;
using Leha.Core.Features.Forms.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Forms.Quaries.Models;

public class GetFormDetailsQuery : IRequest<Response<GetFormDetailsResponse>>
{
    public int Id { get; set; }

    public GetFormDetailsQuery(int formID)
    {
        Id = formID;
    }
    public GetFormDetailsQuery()
    {
    }
}
