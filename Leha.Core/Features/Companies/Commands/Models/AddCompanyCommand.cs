using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class AddCompanyCommand : IRequest<Response<string>>
{
    public string CompanyName { get; set; }
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhone { get; set; }
    public AddCompanyCommand(string companyName, int companyEmployees, string companyImage, string companyEmail, string companyPhone)
    {
        CompanyName = companyName;
        CompanyEmployees = companyEmployees;
        CompanyImage = companyImage;
        CompanyEmail = companyEmail;
        CompanyPhone = companyPhone;
    }
    public AddCompanyCommand()
    {

    }
}

