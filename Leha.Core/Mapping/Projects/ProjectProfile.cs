namespace Leha.Core.Mapping.Projects;


public partial class ProjectProfile
{
    public ProjectProfile()
    {
        GetProjectByIdMapping();
        GetProjectListMapping();
        GetProjectListByCompanyIDMapping();
        AddProjectCommandMapping();
        UpdateProjectCommandMapping();
    }
}
