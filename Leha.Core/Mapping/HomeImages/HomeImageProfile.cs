namespace Leha.Core.Mapping.HomeImages;


public partial class HomeImageProfile
{
    public HomeImageProfile()
    {
        GetHomeImageByIdMapping();
        GetHomeImageListMapping();
        GetHomeImageListByCompanyIDMapping();
        AddHomeImageCommandMapping();
        UpdateHomeImageCommandMapping();
    }
}
