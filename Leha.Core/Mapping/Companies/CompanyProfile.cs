﻿namespace Leha.Core.Mapping.Companies
{
    public partial class CompanyProfile
    {
        public CompanyProfile()
        {
            GetCountryListMapping();
            GetCompanyByIdMapping();
            GetCompanyDetailsMapping();
            AddCompanyCommandMapping();
            UpdateCompanyCommandMapping();
        }
    }
}
