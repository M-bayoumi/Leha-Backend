
namespace Leha.Data.Entities;

public class Service
{
    public int ID { get; set; }
    public string ServcieTitle { get; set; } = string.Empty;
    public string ServcieDescription { get; set; } = string.Empty;
    public string ServcieImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Service()
    {
    }

    public Service(int iD, string servcieTitle, string servcieDescription, string servcieImage, int companyID, Company company)
    {
        ID = iD;
        ServcieTitle = servcieTitle;
        ServcieDescription = servcieDescription;
        ServcieImage = servcieImage;
        CompanyID = companyID;
        Company = company;
    }
}
