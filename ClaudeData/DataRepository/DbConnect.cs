using System.Web.Configuration;

namespace ClaudeData.DataRepository
{
    public abstract class DbConnect
    {
        public static string GetClaudeConnStr()
        {
            return WebConfigurationManager.ConnectionStrings["ClaudeConnection"].ConnectionString;
        }
    }
}