using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Models;

public class AddFormCommand : IRequest<Response<string>>
{
    public string FormFullName { get; set; } = string.Empty;
    public string FormAddress { get; set; } = string.Empty;
    public string FormJobTitle { get; set; } = string.Empty;
    public string FormCV { get; set; } = string.Empty;
    public int JobID { get; set; }

    public AddFormCommand()
    {

    }

    public AddFormCommand(string formFullName, string formAddress, string formJobTitle, string formCV, int jobID)
    {
        FormFullName = formFullName;
        FormAddress = formAddress;
        FormJobTitle = formJobTitle;
        FormCV = formCV;
        JobID = jobID;
    }
}
