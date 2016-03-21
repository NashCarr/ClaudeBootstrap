using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
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