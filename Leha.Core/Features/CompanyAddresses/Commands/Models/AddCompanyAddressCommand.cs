using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class AddCompanyAddressCommand : IRequest<Response<string>>
{
    public string Address { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddCompanyAddressCommand()
    {

    }

    public AddCompanyAddressCommand(string address, int companyID)
    {
        Address = address;
        CompanyID = companyID;
    }
}
