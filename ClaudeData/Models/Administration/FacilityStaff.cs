using ClaudeData.BaseModels;

namespace ClaudeData.Models.Administration
{
    public class FacilityStaff : ModelBase
    {
        public FacilityStaff()
        {
            FacilityId = 0;
            StaffUserId = 0;
            FacilityStaffId = 0;
        }

        public int FacilityId { get; set; }
        public int StaffUserId { get; set; }
        public int FacilityStaffId { get; set; }
    }
}