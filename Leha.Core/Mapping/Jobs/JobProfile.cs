namespace Leha.Core.Mapping.Jobs;


public partial class JobProfile
{
    public JobProfile()
    {
        GetJobByIDMapping();
        GetJobListMapping();
        GetJobListByCompanyIDMapping();
        AddJobCommandMapping();
        UpdateJobCommandMapping();
    }
}
