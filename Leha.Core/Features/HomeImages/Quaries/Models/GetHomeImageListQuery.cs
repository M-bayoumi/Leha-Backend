using Leha.Core.BaseResponse;
using Leha.Core.Features.HomeImages.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.HomeImages.Quaries.Models;

public class GetHomeImageListQuery : IRequest<Response<List<GetHomeImageListResponse>>>
{
}
