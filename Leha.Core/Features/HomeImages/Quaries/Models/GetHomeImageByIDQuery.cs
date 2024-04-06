using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageByIDQuery : IRequest<Response<GetHomeImageByIDResponse>>
{
    public int ID { get; set; }

    public GetHomeImageByIDQuery(int homeImageID)
    {
        ID = homeImageID;
    }
    public GetHomeImageByIDQuery()
    {
    }
}
