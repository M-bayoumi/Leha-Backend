
namespace Leha.Data.Entities;

public class Service
{
    public int ID { get; set; }
    public string ServiceName { get; set; } = string.Empty;
    public string ServiceDescription { get; set; } = string.Empty;
    public string ServiceImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Service()
    {
    }

    public Service(int iD, string serviceName, string serviceDescription, string serviceImage, int companyID)
    {
        ID = iD;
        ServiceName = serviceName;
        ServiceDescription = serviceDescription;
        ServiceImage = serviceImage;
        CompanyID = companyID;
    }
}

