
namespace Leha.Data.Entities;

public class Company
{
    public int ID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public List<Service> Services { get; set; } = new List<Service>();

    public Company()
    {
    }

    public Company(int iD, string companyName, int companyEmployees, string companyImage, string companyEmail, string companyPhone)
    {
        ID = iD;
        CompanyName = companyName;
        CompanyEmployees = companyEmployees;
        CompanyImage = companyImage;
        CompanyEmail = companyEmail;
        CompanyPhone = companyPhone;
    }
}
