namespace Leha.Core.Mapping.HomeImages;


public partial class HomeImageProfile
{
    public HomeImageProfile()
    {
        GetHomeImageByIDMapping();
        GetHomeImageListMapping();
        GetHomeImageListByCompanyIDMapping();
        AddHomeImageCommandMapping();
        UpdateHomeImageCommandMapping();
    }
}
