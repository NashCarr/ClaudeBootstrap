using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeViewManagement.ViewModels.People
{
    public class ContactSaveModel
    {
        public int PlaceId { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public PersonType PersonType { get; set; }
    }
}