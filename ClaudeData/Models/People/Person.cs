using ClaudeData.BaseModels;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.Models.People
{
    public class Person : ModelBase
    {
        public Person()
        {
            PlaceId = 0;
            PersonId = 0;
            Email = string.Empty;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            PersonType = PersonType.None;
            PersonTypeName = string.Empty;
        }

        public int PlaceId { get; set; }

        public int PersonId { get; set; }

        public PersonType PersonType { get; set; }

        public string PersonTypeName { get; set; }

        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}