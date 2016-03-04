using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeCommon.Models
{
    public class Contact
    {
        public Contact()
        {
            PlaceId = 0;
            PersonId = 0;
            Email = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            PersonType = PersonType.None;
        }

        public int PlaceId { get; set; }
        public int PersonId { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public PersonType PersonType { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}