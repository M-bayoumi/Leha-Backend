namespace Leha.Core.Mapping.Projects;


public partial class ProjectProfile
{
    public ProjectProfile()
    {
        GetProjectByIDMapping();
        GetProjectListMapping();
        GetProjectListByCompanyIDMapping();
        AddProjectCommandMapping();
        UpdateProjectCommandMapping();
    }
}
