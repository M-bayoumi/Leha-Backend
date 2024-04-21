namespace Leha.Core.Mapping.Jobs;


public partial class JobProfile
{
    public JobProfile()
    {
        GetJobByIdMapping();
        GetJobListMapping();
        GetJobDetailsMapping();
        GetJobListByCompanyIDMapping();
        AddJobCommandMapping();
        UpdateJobCommandMapping();
    }
}
