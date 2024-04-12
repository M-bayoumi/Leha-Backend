namespace Leha.Core.Features.Companies.Queries.Results;

public class GetCompanyByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slogan { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;

}
