
namespace Leha.Data.Entities;

public class HomeImage
{
    public int ID { get; set; }
    public byte[] HomeImageBytes { get; set; }

    public HomeImage()
    {
        HomeImageBytes = new byte[0];
    }
}
