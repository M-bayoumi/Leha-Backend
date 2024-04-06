using Leha.Core.BaseResponse;
using MediatR;

namespace Leha.Core.Features.Forms.Commands.Models;

public class UpdateFormCommand : IRequest<Response<string>>
{
    public int ID { get; set; }
    public string FormFullName { get; set; } = string.Empty;
    public string FormAddress { get; set; } = string.Empty;
    public string FormJobTitle { get; set; } = string.Empty;
    public string FormCV { get; set; } = string.Empty;
    public int JobID { get; set; }
    public UpdateFormCommand()
    {

    }

    public UpdateFormCommand(int iD, string formFullName, string formAddress, string formJobTitle, string formCV, int jobID)
    {
        ID = iD;
        FormFullName = formFullName;
        FormAddress = formAddress;
        FormJobTitle = formJobTitle;
        FormCV = formCV;
        JobID = jobID;
    }
}
