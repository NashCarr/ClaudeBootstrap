﻿using System.ComponentModel.DataAnnotations;
using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PersonEnums;
using static CommonData.Enums.TimeZoneEnums;

namespace DataLayerCommon.People
{
    public class PersonBase
    {
        public PersonBase()
        {
            PlaceId = 0;
            PersonId = 0;
            DisplayOrder = 0;
            Email = string.Empty;
            Country = Country.None;
            LastName = string.Empty;
            FirstName = string.Empty;
            MiddleName = string.Empty;
            PersonType = PersonType.None;
            TimeZone = ClaudeTimeZone.None;
        }

        public int PlaceId { get; set; }
        public int PersonId { get; set; }

        [Display(Name = "Order")]
        public short DisplayOrder { get; set; }

        public string Email { get; set; }
        public Country Country { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public PersonType PersonType { get; set; }
        public ClaudeTimeZone TimeZone { get; set; }

        public string FullName => ((FirstName + ' ' + MiddleName).Trim() + ' ' + LastName).Trim();
    }
}