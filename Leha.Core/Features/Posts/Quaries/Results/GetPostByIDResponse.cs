namespace Leha.Core.Features.Posts.Quaries.Results;

public class GetPostByIdResponse
{
    public int ID { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public string PostImage { get; set; } = string.Empty;
    public DateTime PostDateTime { get; set; } = DateTime.Now;
    public int CompanyID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
