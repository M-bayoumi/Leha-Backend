using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Models;

public class AddJobCommand : IRequest<Response<string>>
{
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string JobAverageSalary { get; set; } = string.Empty;
    public int CompanyID { get; set; }

    public AddJobCommand()
    {

    }

    public AddJobCommand(string jobTitle, string jobDescription, string jobAverageSalary, int companyID)
    {
        JobTitle = jobTitle;
        JobDescription = jobDescription;
        JobAverageSalary = jobAverageSalary;
        CompanyID = companyID;
    }
}
