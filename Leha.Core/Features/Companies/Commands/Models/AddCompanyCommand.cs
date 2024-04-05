﻿using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class AddCompanyCommand : IRequest<Response<string>>
{
    public string CompanyName { get; set; } = string.Empty;
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; } = string.Empty;
    public string CompanyEmail { get; set; } = string.Empty;
    public string CompanyPhone { get; set; } = string.Empty;
    public string CompanyLink { get; set; } = string.Empty;

    public AddCompanyCommand(string companyName, int companyEmployees, string companyImage, string companyEmail, string companyPhone, string companyLink)
    {
        CompanyName = companyName;
        CompanyEmployees = companyEmployees;
        CompanyImage = companyImage;
        CompanyEmail = companyEmail;
        CompanyPhone = companyPhone;
        CompanyLink = companyLink;
    }
    public AddCompanyCommand()
    {

    }

}

