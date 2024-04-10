namespace Leha.Core.Features.HomeImages.Quaries.Results;

public class GetHomeImageByIdResponse
{
    public int Id { get; set; }
    public string ImageBytes { get; set; } = string.Empty;
    public int CompanyId { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
}
