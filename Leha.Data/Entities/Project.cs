
namespace Leha.Data.Entities;

public class Project
{
    public int ID { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string SiteEngineerName { get; set; } = string.Empty;
    public decimal Progresspercentage { get; set; }
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;
    public List<ProjectPhase> ProjectPhases { get; set; } = new List<ProjectPhase>();


    public Project()
    {
    }

    public Project(int iD, string projectName, string projectDescription, string projectAddress, string projectImage, string siteEngineerName, decimal progresspercentage, int companyID)
    {
        ID = iD;
        ProjectName = projectName;
        ProjectDescription = projectDescription;
        ProjectAddress = projectAddress;
        ProjectImage = projectImage;
        SiteEngineerName = siteEngineerName;
        Progresspercentage = progresspercentage;
        CompanyID = companyID;
    }
}


