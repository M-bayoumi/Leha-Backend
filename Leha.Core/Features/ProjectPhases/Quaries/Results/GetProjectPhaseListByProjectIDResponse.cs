namespace Leha.Core.Features.ProjectPhases.Quaries.Results;

public class GetProjectPhaseListByProjectIDResponse
{
    public int ID { get; set; }
    public string ProjectPhaseName { get; set; } = string.Empty;
    public int ProjectID { get; set; }
    public string ProjectName { get; set; } = string.Empty;
    public string ProjectDescription { get; set; } = string.Empty;
    public string ProjectAddress { get; set; } = string.Empty;
    public string ProjectImage { get; set; } = string.Empty;
    public string SiteEngineerName { get; set; } = string.Empty;
    public decimal ProjectProgressPercentage { get; set; }
}
