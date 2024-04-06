namespace Leha.Core.Mapping.Posts;


public partial class PostProfile
{
    public PostProfile()
    {
        GetPostByIDMapping();
        GetPostListMapping();
        GetPostListByCompanyIDMapping();
        AddPostCommandMapping();
        UpdatePostCommandMapping();
    }
}
