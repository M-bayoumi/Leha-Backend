﻿
namespace Leha.Data.Entities;

public class HomeImage
{
    public int ID { get; set; }
    public string HomeImageBytes { get; set; } = string.Empty;
    public int CompanyID { get; set; }
    public Company Company { get; set; } = null!;
    public HomeImage()
    {
    }

    public HomeImage(int iD, string homeImageBytes, int companyID)
    {
        ID = iD;
        HomeImageBytes = homeImageBytes;
        CompanyID = companyID;
    }
}