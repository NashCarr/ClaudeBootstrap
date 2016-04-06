namespace CommonDataSave.Facility
{
    public class FacilityStaffSave
    {
        public FacilityStaffSave()
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