
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Company : LocalizableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;
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

    public Company(int id, string nameAr, string nameEn, int employees, string image, string email, string phone, string link)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        Employees = employees;
        Image = image;
        Email = email;
        Phone = phone;
        Link = link;
    }
}
