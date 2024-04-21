namespace Leha.Core.Mapping.Products;


public partial class ProductProfile
{
    public ProductProfile()
    {
        GetProductByIdMapping();
        GetProductListMapping();
        GetProductDetailsMapping();
        GetProductListByCompanyIDMapping();
        AddProductCommandMapping();
        UpdateProductCommandMapping();
    }
}
