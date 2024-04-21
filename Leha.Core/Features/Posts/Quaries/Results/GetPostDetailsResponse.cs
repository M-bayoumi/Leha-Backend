namespace Leha.Core.Features.Posts.Quaries.Results;

public class GetPostDetailsResponse
{
    public int Id { get; set; }
    public string ContentAr { get; set; } = string.Empty;
    public string ContentEn { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public int CompanyId { get; set; }
}
