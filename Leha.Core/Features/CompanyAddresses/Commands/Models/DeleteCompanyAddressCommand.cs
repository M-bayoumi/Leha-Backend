using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class DeleteCompanyAddressCommand : IRequest<Response<string>>
{
    public int ID { get; set; }

    public DeleteCompanyAddressCommand()
    {

    }

    public DeleteCompanyAddressCommand(int iD)
    {
        ID = iD;
    }
}
