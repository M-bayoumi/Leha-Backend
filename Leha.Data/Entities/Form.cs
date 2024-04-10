
using Leha.Data.Commons;

namespace Leha.Data.Entities;

public class Form : LocalizableEntity
{
    public int Id { get; set; }
    public string FullNameAr { get; set; } = string.Empty;
    public string FullNameEn { get; set; } = string.Empty;
    public string AddressAr { get; set; } = string.Empty;
    public string AddressEn { get; set; } = string.Empty;
    public string JobTitleAr { get; set; } = string.Empty;
    public string JobTitleEn { get; set; } = string.Empty;
    public string CV { get; set; } = string.Empty;
    public DateTime DateTime { get; set; } = DateTime.Now;
    public int JobId { get; set; }
    public Job Job { get; set; } = null!;

    public Form()
    {
    }

    public Form(int id,
        string fullNameAr, string fullNameEn,
        string addressAr, string addressEn,
        string jobTitleAr, string jobTitleEn,
        string cV, int jobId)
    {
        Id = id;
        FullNameAr = fullNameAr;
        FullNameEn = fullNameEn;
        AddressAr = addressAr;
        AddressEn = addressEn;
        JobTitleAr = jobTitleAr;
        JobTitleEn = jobTitleEn;
        CV = cV;
        JobId = jobId;
    }
}


