using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageByIdQuery : IRequest<Response<GetHomeImageByIdResponse>>
{
    public int ID { get; set; }

    public GetHomeImageByIdQuery(int homeImageID)
    {
        ID = homeImageID;
    }
    public GetHomeImageByIdQuery()
    {
    }
}
