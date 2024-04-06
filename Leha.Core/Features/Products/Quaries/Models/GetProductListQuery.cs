using Leha.Core.BaseResponse;
using Leha.Core.Features.BoardMemberSpeeches.Quaries.Results;
using Leha.Core.Features.Products.Quaries.Results;
using MediatR;

namespace Leha.Core.Features.Products.Quaries.Models;

public class GetProductListQuery : IRequest<Response<List<GetProductListResponse>>>
{
}
