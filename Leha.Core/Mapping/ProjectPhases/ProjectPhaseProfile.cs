namespace Leha.Core.Mapping.ProjectPhases;


public partial class ProjectPhaseProfile
{
    public ProjectPhaseProfile()
    {
        GetProjectPhaseByIDMapping();
        GetProjectPhaseListMapping();
        GetProjectPhaseListByCompanyIDMapping();
        AddProjectPhaseCommandMapping();
        UpdateProjectPhaseCommandMapping();
    }
}
