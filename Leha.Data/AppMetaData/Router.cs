namespace Leha.Data.AppMetaData;

public static class Router
{
    private const string Root = "Api/";
    private const string Version = "V1/";
    private const string Rule = Root + Version;

    private const string ListRoute = "List";
    private const string GetByIDRoute = "{ID}";
    private const string AddRoute = "Add";
    private const string UpdateRoute = "Update";
    private const string DeleteRoute = "{ID}";

    public static class CompanyRouting
    {
        private const string Prefix = Rule + "Company/";
        public const string GetList = Prefix + ListRoute;
        public const string GetByID = Prefix + GetByIDRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class BoardMemberRouting
    {
        private const string Prefix = Rule + "BoardMember/";
        public const string GetList = Prefix + ListRoute;
        public const string GetByID = Prefix + GetByIDRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }
    public static class BoardMemberSpeechRouting
    {
        private const string Prefix = Rule + "BoardMemberSpeech/";
        public const string GetList = Prefix + ListRoute;
        public const string GetListByBoardMemberID = Prefix + ListRoute + "/{ID}";
        public const string GetByID = Prefix + GetByIDRoute;
        public const string Add = Prefix + AddRoute;
        public const string Update = Prefix + UpdateRoute;
        public const string Delete = Prefix + DeleteRoute;
    }

}
