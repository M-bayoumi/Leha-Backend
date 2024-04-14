namespace Leha.Data.AppMetaData;

public static class Router
{
    private const string Root = "Api/";
    private const string Version = "V1/";
    private const string Rule = Root + Version;

    private const string GetAllRoute = "All";
    private const string GetByIdRoute = "{Id}";
    private const string AddRoute = "Add";
    private const string UpdateRoute = "Update";
    private const string DeleteRoute = "{Id}";
    public static class AppUserRouting
    {
        private const string Prefix = Rule + "User/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
        public const string ChangePassword = Prefix + "ChangePassword";
    }
    public static class BoardMemberRouting
    {
        private const string Prefix = Rule + "Member/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class BoardMemberSpeechRouting
    {
        private const string Prefix = Rule + "Speech/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByBoardMemberId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class ClientRouting
    {
        private const string Prefix = Rule + "Client/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class CompanyAddressRouting
    {
        private const string Prefix = Rule + "Address/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }

    public static class CompanyRouting
    {
        private const string Prefix = Rule + "Company/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class FormRouting
    {
        private const string Prefix = Rule + "Form/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByJobId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class HomeImageRouting
    {
        private const string Prefix = Rule + "HomeImage/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class JobRouting
    {
        private const string Prefix = Rule + "Job/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class PhaseItemRouting
    {
        private const string Prefix = Rule + "Item/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByProjectPhaseId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class PostRouting
    {
        private const string Prefix = Rule + "Post/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class ProductRouting
    {
        private const string Prefix = Rule + "Product/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class ProjectRouting
    {
        private const string Prefix = Rule + "Project/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class ProjectPhaseRouting
    {
        private const string Prefix = Rule + "Phase/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByProjectId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class ServiceRouting
    {
        private const string Prefix = Rule + "Service/";
        public const string GetAll = Prefix + GetAllRoute;
        public const string GetAllByCompanyId = Prefix + GetAllRoute + "/{Id}";
        public const string GetById = Prefix + GetByIdRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
}
