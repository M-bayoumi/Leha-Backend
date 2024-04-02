
namespace Leha.Data.Entities;

public class Form
{
    public int ID { get; set; }
    public string FormFullName { get; set; } = string.Empty;
    public string FormAddress { get; set; } = string.Empty;
    public string FormJobTitle { get; set; } = string.Empty;
    public string FormCV { get; set; } = string.Empty;
    public DateTime FormDateTime { get; set; } = DateTime.Now;
    public int JobID { get; set; }
    public Job Job { get; set; } = null!;

    public Form()
    {
    }

    public Form(int iD, string formFullName, string formAddress, string formJobTitle, string formCV, DateTime formDateTime, int jobID)
    {
        ID = iD;
        FormFullName = formFullName;
        FormAddress = formAddress;
        FormJobTitle = formJobTitle;
        FormCV = formCV;
        FormDateTime = formDateTime;
        JobID = jobID;
    }
}


