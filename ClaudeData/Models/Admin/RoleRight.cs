using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class RoleRight : AdminBase
    {
        public RoleRight()
        {
            UserRoleId = 0;
            ProgramOptionId = 0;
        }

        public int UserRoleId { get; set; }
        public int ProgramOptionId { get; set; }
    }
}