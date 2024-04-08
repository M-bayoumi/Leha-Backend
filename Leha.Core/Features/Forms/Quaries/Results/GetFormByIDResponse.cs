namespace Leha.Core.Features.Forms.Quaries.Results;

public class GetFormByIdResponse
{
    public int ID { get; set; }
    public string FormFullName { get; set; } = string.Empty;
    public string FormAddress { get; set; } = string.Empty;
    public string FormJobTitle { get; set; } = string.Empty;
    public string FormCV { get; set; } = string.Empty;
    public DateTime FormDateTime { get; set; } = DateTime.Now;
    public int JobID { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string JobAverageSalary { get; set; } = string.Empty;
    public DateTime JobDateTime { get; set; } = DateTime.Now;
}
