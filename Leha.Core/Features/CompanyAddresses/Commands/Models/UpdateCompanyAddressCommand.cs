using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class UpdateCompanyAddressCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public int CompanyId { get; set; }

    public UpdateCompanyAddressCommand()
    {

    }

    public UpdateCompanyAddressCommand(int id, string addressAr, string addressEn, int companyId)
    {
        Id = id;
        AddressAr = addressAr;
        AddressEn = addressEn;
        CompanyId = companyId;
    }
}
