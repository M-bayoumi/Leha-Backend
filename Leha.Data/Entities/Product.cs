
namespace Leha.Data.Entities;

public class Product
{
    public int ID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Product()
    {
    }

    public Product(int iD, string productName, string productDescription, string productImage, int companyID)
    {
        ID = iD;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductImage = productImage;
        CompanyID = companyID;
    }
}
