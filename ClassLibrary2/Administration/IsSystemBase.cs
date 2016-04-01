using ViewCommon.Base;

namespace ViewCommon.Administration
{
    public class IsSystemBase : AdministrationBase
    {
        public IsSystemBase()
        {
            IsSystem = false;
            IsSystemSort = string.Empty;
        }

        public bool IsSystem { get; set; }
        public string IsSystemSort { get; set; }
    }
}