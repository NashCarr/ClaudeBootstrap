using DataManagement.BaseModels;

namespace DataManagement.Models.Administration
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