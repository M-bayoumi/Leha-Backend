using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class AddCompanyAddressCommand : IRequest<Response<string>>
{
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public AddCompanyAddressCommand()
    {

    }

    public AddCompanyAddressCommand(string addressAr, string addressEn, int companyId)
    {
        AddressAr = addressAr;
        AddressEn = addressEn;
        CompanyId = companyId;
    }
}
