
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class ProjectPhase : LocalizableEntity
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public Project Project { get; set; } = null!;
    public List<PhaseItem> PhaseItems { get; set; } = new List<PhaseItem>();

    public ProjectPhase()
    {
    }

    public ProjectPhase(int id, string nameAr, string nameEn, int projectId)
    {
        Id = id;
        NameAr = nameAr;
        NameEn = nameEn;
        ProjectId = projectId;
    }
}
