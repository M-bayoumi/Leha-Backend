using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Jobs.Commands.Models;

public class UpdateJobCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string JobAverageSalary { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public UpdateJobCommand()
    {

    }

    public UpdateJobCommand(int iD, string jobTitle, string jobDescription, string jobAverageSalary, int companyID)
    {
        ID = iD;
        JobTitle = jobTitle;
        JobDescription = jobDescription;
        JobAverageSalary = jobAverageSalary;
        CompanyID = companyID;
    }
}
