namespace Leha.Core.Mapping.Posts;


public partial class PostProfile
{
    public PostProfile()
    {
        GetPostByIdMapping();
        GetPostListMapping();
        GetPostListByCompanyIDMapping();
        AddPostCommandMapping();
        UpdatePostCommandMapping();
    }
}
