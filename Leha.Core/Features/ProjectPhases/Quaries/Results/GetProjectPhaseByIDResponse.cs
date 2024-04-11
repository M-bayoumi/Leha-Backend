namespace Leha.Core.Features.ProjectPhases.Quaries.Results;

public class GetProjectPhaseByIdResponse
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int ProjectId { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string ProjectSiteEngineerName { get; set; } = string.Empty;
    public decimal ProjectProgressPercentage { get; set; }
}
