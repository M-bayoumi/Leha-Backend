using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageByIdQuery : IRequest<Response<GetHomeImageByIdResponse>>
{
    public int Id { get; set; }

    public GetHomeImageByIdQuery(int homeImageID)
    {
        Id = homeImageID;
    }
    public GetHomeImageByIdQuery()
    {
    }
}
