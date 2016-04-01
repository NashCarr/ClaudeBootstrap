using CommonData.Models.People;

namespace CommonData.Models.Facility
{
    public class StaffMemberList : PersonList
    {
        public StaffMemberList()
        {
            UserName = string.Empty;
            LastLoginDate = string.Empty;
            AccessRightName = string.Empty;
        }

        public string UserName { get; set; }
        public string LastLoginDate { get; set; }
        public string AccessRightName { get; set; }
    }
}