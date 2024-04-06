using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Models;

public class UpdateProductCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public UpdateProductCommand()
    {

    }

    public UpdateProductCommand(int iD, string productName, string productDescription, string productImage, int companyID)
    {
        ID = iD;
        ProductName = productName;
        ProductDescription = productDescription;
        ProductImage = productImage;
        CompanyID = companyID;
    }
}
