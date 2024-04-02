using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class DeleteCompanyCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public DeleteCompanyCommand(int companyID)
    {
        ID = companyID;
    }
    public DeleteCompanyCommand()
    {
    }
}