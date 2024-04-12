using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Companies.Commands.Models;

public class UpdateCompanyCommand : IRequest<Response<string>>
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public string SloganAr { get; set; } = string.Empty;
    public string SloganEn { get; set; } = string.Empty;
    public int Employees { get; set; }
    public string Image { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public string Link { get; set; } = string.Empty;

    public UpdateCompanyCommand()
    {

    }

    public UpdateCompanyCommand(
        int id,
        string nameAr, string nameEn,
        string sloganAr, string sloganEn,
        int employees,
        string image,
        string email,
        string phone,
        string link)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        SloganAr = sloganAr;
        SloganEn = sloganEn;
        Employees = employees;
        Image = image;
        Email = email;
        Phone = phone;
        Link = link;
    }
}
