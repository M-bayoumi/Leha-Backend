namespace Leha.Core.Features.ProjectPhases.Quaries.Results;

public class GetProjectPhaseDetailsResponse
{
    public int Id { get; set; }
    public string NameAr { get; set; } = string.Empty;
    public string NameEn { get; set; } = string.Empty;
    public int ProjectId { get; set; }
}
