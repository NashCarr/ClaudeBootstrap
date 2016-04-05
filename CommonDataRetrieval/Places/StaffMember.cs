using CommonDataRetrieval.People;

namespace CommonDataRetrieval.Places
{
    public class StaffMember : PersonList
    {
        public StaffMember()
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