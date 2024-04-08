namespace Leha.Core.Mapping.PhaseItems;


public partial class PhaseItemProfile
{
    public PhaseItemProfile()
    {
        GetPhaseItemByIdMapping();
        GetPhaseItemListMapping();
        GetPhaseItemListByProjectPhaseIDMapping();
        AddPhaseItemCommandMapping();
        UpdatePhaseItemCommandMapping();
    }
}
