using DataManagement.BaseModels;

namespace DataManagement.Models.Administration
{
    public class FacilityStaff : ModelBase
    {
        public FacilityStaff()
        {
            FacilityId = 0;
            StaffMemberId = 0;
            FacilityStaffId = 0;
        }

        public int FacilityId { get; set; }
        public int StaffMemberId { get; set; }
        public int FacilityStaffId { get; set; }
    }
}