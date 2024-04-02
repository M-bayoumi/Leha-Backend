
namespace Leha.Data.Entities;

public class Company
{
    public int ID { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public List<CompanyAddress> CompanyAddresses { get; set; } = new List<CompanyAddress>();
    public List<HomeImage> HomeImages { get; set; } = new List<HomeImage>();
    public List<Service> Services { get; set; } = new List<Service>();
    public List<Product> Products { get; set; } = new List<Product>();
    public List<Post> Posts { get; set; } = new List<Post>();
    public List<Client> Clients { get; set; } = new List<Client>();
    public List<Job> Jobs { get; set; } = new List<Job>();
    public List<Project> Projects { get; set; } = new List<Project>();


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
