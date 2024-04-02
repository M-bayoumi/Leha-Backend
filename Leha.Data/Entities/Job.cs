
namespace Leha.Data.Entities;

public class Job
{
    public int ID { get; set; }
    public string JobTitle { get; set; } = string.Empty;
    public string JobDescription { get; set; } = string.Empty;
    public string JobAverageSalary { get; set; } = string.Empty;
    public DateTime JobDateTime { get; set; } = DateTime.Now;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;
    public List<Form> Forms { get; set; } = new List<Form>();

    public Job()
    {
    }

    public Job(int iD, string jobTitle, string jobDescription, string jobAverageSalary, DateTime jobDateTime, int companyID)
    {
        ID = iD;
        JobTitle = jobTitle;
        JobDescription = jobDescription;
        JobAverageSalary = jobAverageSalary;
        JobDateTime = jobDateTime;
        CompanyID = companyID;
    }
}


