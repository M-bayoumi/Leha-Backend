namespace Leha.Core.Features.Jobs.Quaries.Results;

public class GetJobListResponse
{
    public int ID { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string JobAverageSalary { get; set; } = string.Empty;
    public DateTime JobDateTime { get; set; } = DateTime.Now;
    public int CompanyID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
