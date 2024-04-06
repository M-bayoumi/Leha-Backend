namespace Leha.Core.Mapping.PhaseItems;


public partial class PhaseItemProfile
{
    public PhaseItemProfile()
    {
        GetPhaseItemByIDMapping();
        GetPhaseItemListMapping();
        GetPhaseItemListByProjectPhaseIDMapping();
        AddPhaseItemCommandMapping();
        UpdatePhaseItemCommandMapping();
    }
}
