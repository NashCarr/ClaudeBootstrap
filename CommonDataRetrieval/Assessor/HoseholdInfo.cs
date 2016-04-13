using CommonDataRetrieval.Base;

namespace CommonDataRetrieval.Assessor
{
    public class HouseholdInfo : ModelBase
    {
        public HouseholdInfo()
        {
            Age = 0;
            Gender = string.Empty;
            Address = string.Empty;
            LastLoginDate = string.Empty;
            RegistrationDate = string.Empty;
            RelationshipName = string.Empty;
        }

        public short Age { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string RelationshipName { get; set; }
        public string RegistrationDate { get; set; }
        public string LastLoginDate { get; set; }
    }
}