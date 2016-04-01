using System.ComponentModel.DataAnnotations;
using CommonData.Enums;
using DataManagement.BaseModels;

namespace DataManagement.Models.People
{
    public class Person : ModelBase
    {
        public Person()
        {
            PlaceId = 0;
            PersonId = 0;
            DisplayOrder = 0;
            Email = string.Empty;
            Country = CountryEnums.Country.None;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            PersonType = PersonEnums.PersonType.None;
            TimeZone = TimeZoneEnums.ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public int PersonId { get; set; }

        [Display(Name = "Order")]
        public short DisplayOrder { get; set; }

        public string Email { get; set; }
        public CountryEnums.Country Country { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public PersonEnums.PersonType PersonType { get; set; }
        public TimeZoneEnums.ClaudeTimeZone TimeZone { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}