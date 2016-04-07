using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Facility
{
    public class StaffMemberViewModel
    {
        public StaffMemberViewModel(int id)
        {
            using (PlaceContactGetManager db = new PlaceContactGetManager())
            {
                StaffMember = db.GetStaffMember(id);
            }
        }

        public PersonView StaffMember { get; set; }
    }
}