using AutoMapper;
using Leha.Core.Features.Posts.Commands.Models;
using Leha.Data.Entities;

namespace Leha.Core.Mapping.Posts;


public partial class PostProfile : Profile
{
    public void UpdatePostCommandMapping()
    {
        CreateMap<UpdatePostCommand, Post>();
    }
}