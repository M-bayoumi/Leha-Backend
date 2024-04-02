namespace Leha.Core.Mapping.Companies
{
    public partial class CompanyProfile
    {
        public CompanyProfile()
        {
            GetCountryListMapping();
            GetCompanyByIDMapping();
            AddCompanyCommandMapping();
            UpdateCompanyCommandMapping();
        }
    }
}
