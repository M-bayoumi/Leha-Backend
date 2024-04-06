namespace Leha.Core.Features.Projects.Quaries.Results;

public class GetProjectListResponse
{
    public int ID { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string SiteEngineerName { get; set; } = string.Empty;
    public decimal ProjectProgressPercentage { get; set; }
    public int CompanyID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
