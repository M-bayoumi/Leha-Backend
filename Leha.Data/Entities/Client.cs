
namespace Leha.Data.Entities;

public class Client
{
    public int ID { get; set; }
    public string ClientName { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Client()
    {
    }

    public Client(int iD, string clientName, string clientImage, int companyID)
    {
        ID = iD;
        ClientName = clientName;
        ClientImage = clientImage;
        CompanyID = companyID;
    }
}

