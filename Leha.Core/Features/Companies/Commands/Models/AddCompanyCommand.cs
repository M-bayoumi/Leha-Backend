﻿using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class AddCompanyCommand : IRequest<Response<string>>
{
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;

    public AddCompanyCommand()
    {

    }

    public AddCompanyCommand(string nameAr, string nameEn, int employees, string image, string email, string phone, string link)
    {
        NameAr = nameAr;
        NameEn = nameEn;
        Employees = employees;
        Image = image;
        Email = email;
        Phone = phone;
        Link = link;
    }
}

