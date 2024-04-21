using AutoMapper;
using Leha.Core.Features.Posts.Quaries.Results;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Posts;
public partial class PostProfile : Profile
{
    public void GetPostDetailsMapping()
    {
        CreateMap<Post, GetPostDetailsResponse>();
    }
}
