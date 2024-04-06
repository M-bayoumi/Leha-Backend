namespace Leha.Core.Features.HomeImages.Quaries.Results;

public class GetHomeImageByIDResponse
{
    public int ID { get; set; }
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;
}
