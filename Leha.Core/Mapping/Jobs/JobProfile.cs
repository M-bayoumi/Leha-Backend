namespace Leha.Core.Mapping.Jobs;


public partial class JobProfile
{
    public JobProfile()
    {
        GetJobByIdMapping();
        GetJobListMapping();
        GetJobListByCompanyIDMapping();
        AddJobCommandMapping();
        UpdateJobCommandMapping();
    }
}
