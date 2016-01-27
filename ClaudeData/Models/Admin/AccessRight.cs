using ClaudeData.BaseModels;

namespace ClaudeData.Models.Admin
{
    public class AccessRight : AdminBase
    {
        public AccessRight()
        {
            StaffUserId = 0;
            ProgramOptionId = 0;
        }

        public int StaffUserId { get; set; }
        public int ProgramOptionId { get; set; }
    }
}