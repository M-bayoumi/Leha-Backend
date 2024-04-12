namespace Leha.Core.Features.Jobs.Quaries.Results;

public class GetJobListByCompanyIDResponse
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AverageSalary { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int CompanyId { get; set; }
    public string CompanySlogan { get; set; } = string.Empty;
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
