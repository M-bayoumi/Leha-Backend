namespace Leha.Core.Mapping.Forms;


public partial class FormProfile
{
    public FormProfile()
    {
        GetFormByIdMapping();
        GetFormListMapping();
        GetFormListByJobIDMapping();
        AddFormCommandMapping();
        UpdateFormCommandMapping();
    }
}
