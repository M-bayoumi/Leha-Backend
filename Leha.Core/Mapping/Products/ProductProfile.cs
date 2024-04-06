namespace Leha.Core.Mapping.Products;


public partial class ProductProfile
{
    public ProductProfile()
    {
        GetProductByIDMapping();
        GetProductListMapping();
        GetProductListByCompanyIDMapping();
        AddProductCommandMapping();
        UpdateProductCommandMapping();
    }
}
