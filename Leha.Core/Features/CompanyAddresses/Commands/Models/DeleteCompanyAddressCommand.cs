using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.CompanyAddresses.Commands.Models;

public class DeleteCompanyAddressCommand : IRequest<Response<string>>
{
    public int Id { get; set; }

    public DeleteCompanyAddressCommand()
    {

    }

    public DeleteCompanyAddressCommand(int iD)
    {
        Id = iD;
    }
}
