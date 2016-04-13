using CommonDataRetrieval.People;
using ManagementRetrieval.People;

namespace ViewData.Facility
{
    public class StaffMemberViewModel
    {
        public StaffMemberViewModel(int id)
        {
            using (PersonViewGetManager mgr = new PersonViewGetManager())
            {
                StaffMember = mgr.GetStaffMember(id);
            }
        }

        public PersonView StaffMember { get; set; }
    }
}