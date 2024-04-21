namespace Leha.Core.Mapping.Projects;


public partial class ProjectProfile
{
    public ProjectProfile()
    {
        GetProjectByIdMapping();
        GetProjectListMapping();
        GetProjectDetailsMapping();
        GetProjectListByCompanyIDMapping();
        AddProjectCommandMapping();
        UpdateProjectCommandMapping();
    }
}
