namespace Leha.Core.Features.Posts.Quaries.Results;

public class GetPostListByCompanyIDResponse
{
    public int Id { get; set; }
    public string Content { get; set; } = string.Empty;
    public string Image { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int CompanyId { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
