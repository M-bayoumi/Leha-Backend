
namespace Leha.Data.Entities;

public class Post
{
    public int ID { get; set; }
    public string PostContent { get; set; } = string.Empty;
    public string ServcieImage { get; set; } = string.Empty;
    public DateTime PostDateTime { get; set; } = DateTime.Now;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;

    public Post()
    {
    }

    public Post(int iD, string postContent, string servcieImage, DateTime postDateTime, int companyID)
    {
        ID = iD;
        PostContent = postContent;
        ServcieImage = servcieImage;
        PostDateTime = postDateTime;
        CompanyID = companyID;
    }
}

