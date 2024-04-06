namespace Leha.Core.Mapping.Forms;


public partial class FormProfile
{
    public FormProfile()
    {
        GetFormByIDMapping();
        GetFormListMapping();
        GetFormListByJobIDMapping();
        AddFormCommandMapping();
        UpdateFormCommandMapping();
    }
}
