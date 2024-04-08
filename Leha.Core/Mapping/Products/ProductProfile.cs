namespace Leha.Core.Mapping.Products;


public partial class ProductProfile
{
    public ProductProfile()
    {
        GetProductByIdMapping();
        GetProductListMapping();
        GetProductListByCompanyIDMapping();
        AddProductCommandMapping();
        UpdateProductCommandMapping();
    }
}
