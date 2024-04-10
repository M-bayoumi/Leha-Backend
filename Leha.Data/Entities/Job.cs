
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Job : LocalizableEntity
{
    public int Id { get; set; }
    public string TitleAr { get; set; } = string.Empty;
    public string TitleEn { get; set; } = string.Empty;
    public string DescriptionAr { get; set; } = string.Empty;
    public string DescriptionEn { get; set; } = string.Empty;
    public string AverageSalary { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int CompanyId { get; set; }
    public Company Company { get; set; } = null!;
    public List<Form> Forms { get; set; } = new List<Form>();

    public Job()
    {
    }

    public Job(int id, string titleAr, string titleEn, string descriptionAr, string descriptionEn, string averageSalary, int companyId)
    {
        Id = id;
        TitleAr = titleAr;
        TitleEn = titleEn;
        DescriptionAr = descriptionAr;
        DescriptionEn = descriptionEn;
        AverageSalary = averageSalary;
        CompanyId = companyId;
    }
}


