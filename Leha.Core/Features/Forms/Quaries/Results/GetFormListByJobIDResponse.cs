namespace Leha.Core.Features.Forms.Quaries.Results;

public class GetFormListByJobIDResponse
{
    public int Id { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string FormJobTitle { get; set; } = string.Empty;
    public string CV { get; set; } = string.Empty;
    public int JobId { get; set; }
    public DateTime FormDateTime { get; set; } = DateTime.Now;
    public string JobTitle { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string AverageSalary { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public DateTime JobDateTime { get; set; } = DateTime.Now;
}
