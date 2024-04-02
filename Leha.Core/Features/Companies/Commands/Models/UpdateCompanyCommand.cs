﻿using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class UpdateCompanyCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string CompanyName { get; set; }
    public int CompanyEmployees { get; set; }
    public string CompanyImage { get; set; }
    public string CompanyEmail { get; set; }
    public string CompanyPhone { get; set; }
    public UpdateCompanyCommand(int iD, string companyName, int companyEmployees, string companyImage, string companyEmail, string companyPhone)
    {
        ID = iD;
        CompanyName = companyName;
        CompanyEmployees = companyEmployees;
        CompanyImage = companyImage;
        CompanyEmail = companyEmail;
        CompanyPhone = companyPhone;
    }
    public UpdateCompanyCommand()
    {

    }

}