namespace Leha.Core.Mapping.Forms;


public partial class FormProfile
{
    public FormProfile()
    {
        GetFormListMapping();
        GetFormByIdMapping();
        GetFormDetailsMapping();
        GetFormListByJobIDMapping();
        AddFormCommandMapping();
        UpdateFormCommandMapping();
    }
}
