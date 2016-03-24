using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
{
    public class AccessRight : AdminBase
    {
        public AccessRight()
        {
            StaffMemberId = 0;
            ProgramOptionId = 0;
        }

        public int StaffMemberId { get; set; }
        public int ProgramOptionId { get; set; }
    }
}