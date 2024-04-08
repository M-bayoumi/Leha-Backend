namespace Leha.Core.Mapping.ProjectPhases;


public partial class ProjectPhaseProfile
{
    public ProjectPhaseProfile()
    {
        GetProjectPhaseByIdMapping();
        GetProjectPhaseListMapping();
        GetProjectPhaseListByCompanyIDMapping();
        AddProjectPhaseCommandMapping();
        UpdateProjectPhaseCommandMapping();
    }
}
