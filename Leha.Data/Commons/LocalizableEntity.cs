using System.Globalization;

namespace Leha.Data.Commons;

public class LocalizableEntity
{
    public string GetLocalized(string nameAr, string nameEn)
    {
        CultureInfo culture = Thread.CurrentThread.CurrentCulture;
        if (culture.TwoLetterISOLanguageName.ToLower().Equals("ar"))
            return nameAr;
        return nameEn;
    }
}

