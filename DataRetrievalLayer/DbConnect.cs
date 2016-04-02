using System.Web.Configuration;

namespace DataRetrievalLayer
{
    public abstract class DbConnect
    {
        public static string GetClaudeConnStr()
        {
            return WebConfigurationManager.ConnectionStrings["ClaudeConnection"].ConnectionString;
        }

        public static string GetGatewayConnStr()
        {
            return WebConfigurationManager.ConnectionStrings["GatewayConnStr"].ConnectionString;
        }
    }
}