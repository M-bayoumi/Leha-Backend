using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Client : LocalizableEntity
{
    public int ID { get; set; }
    public string ClientNameAr { get; set; } = string.Empty;
    public string ClientNameEn { get; set; } = string.Empty;
    public string ClientImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Client()
    {
    }

    public Client(int iD, string clientNameAr, string clientNameEn, string clientImage, int companyID)
    {
        ID = iD;
        ClientNameAr = clientNameAr;
        ClientNameEn = clientNameEn;
        ClientImage = clientImage;
        CompanyID = companyID;
    }
}

