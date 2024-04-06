using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Products.Commands.Models;

public class AddProductCommand : IRequest<Response<string>>
{
    public string ProductName { get; set; } = string.Empty;
    public string ProductDescription { get; set; } = string.Empty;
    public string ProductImage { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddProductCommand()
    {

    }

    public AddProductCommand(string productName, string productDescription, string productImage, int companyID)
    {
        ProductName = productName;
        ProductDescription = productDescription;
        ProductImage = productImage;
        CompanyID = companyID;
    }
}
