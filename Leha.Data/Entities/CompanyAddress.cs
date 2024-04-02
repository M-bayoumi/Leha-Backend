
namespace Leha.Data.Entities;

public class CompanyAddress
{

    public int ID { get; set; }
    public string Address { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;
    public CompanyAddress()
    {
    }

    public CompanyAddress(int iD, string address, int companyID)
    {
        ID = iD;
        Address = address;
        CompanyID = companyID;
    }
}
