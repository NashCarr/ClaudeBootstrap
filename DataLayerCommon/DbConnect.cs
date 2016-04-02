using static System.Web.Configuration.WebConfigurationManager;

namespace DataLayerCommon
{
    public abstract class DbConnect
    {
        public static string GetClaudeConnStr()
        {
            return ConnectionStrings["ClaudeConnection"].ConnectionString;
        }

        public static string GetGatewayConnStr()
        {
            return ConnectionStrings["GatewayConnStr"].ConnectionString;
        }
    }
}