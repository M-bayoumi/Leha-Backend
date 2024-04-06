using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class UpdateCompanyAddressCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string Address { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public UpdateCompanyAddressCommand()
    {

    }

    public UpdateCompanyAddressCommand(int iD, string address, int companyID)
    {
        ID = iD;
        Address = address;
        CompanyID = companyID;
    }
}
