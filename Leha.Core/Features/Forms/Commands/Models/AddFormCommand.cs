using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Models;

public class AddFormCommand : IRequest<Response<string>>
{
    public string FullNameAr { get; set; } = string.Empty;
    public string FullNameEn { get; set; } = string.Empty;
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public string JobTitleAr { get; set; } = string.Empty;
    public string JobTitleEn { get; set; } = string.Empty;
    public string CV { get; set; } = string.Empty;
    public int JobId { get; set; }

    public AddFormCommand()
    {

    }

    public AddFormCommand(
        string fullNameAr, string fullNameEn,
        string addressAr, string addressEn,
        string jobTitleAr, string jobTitleEn,
        string cV,
        int jobId)
    {
        FullNameAr = fullNameAr;
        FullNameEn = fullNameEn;
        AddressAr = addressAr;
        AddressEn = addressEn;
        JobTitleAr = jobTitleAr;
        JobTitleEn = jobTitleEn;
        CV = cV;
        JobId = jobId;
    }
}
