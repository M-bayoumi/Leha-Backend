
namespace Leha.Data.Entities;

public class ProjectPhase
{
    public int ID { get; set; }
    public string ProjectPhaseName { get; set; } = string.Empty;
    public int ProjectID { get; set; }
    public Project Project { get; set; } = null!;
    public List<PhaseItem> PhaseItems { get; set; } = new List<PhaseItem>();

    public ProjectPhase()
    {
    }

    public ProjectPhase(int iD, string projectPhaseName, int projectID)
    {
        ID = iD;
        ProjectPhaseName = projectPhaseName;
        ProjectID = projectID;
    }
}
