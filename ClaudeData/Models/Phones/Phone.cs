using CommonData.Enums;
using DataManagement.BaseModels;

namespace DataManagement.Models.Phones
{
    public abstract class Phone : ModelBase
    {
        protected Phone()
        {
            PhoneId = 0;
            PhoneNumber = 0;
            PhoneType = PhoneEnums.PhoneType.None;
            Country = CountryEnums.Country.UnitedStates;
        }

        public int PhoneId { get; set; }
        public CountryEnums.Country Country { get; set; }
        public long PhoneNumber { get; set; }
        public PhoneEnums.PhoneType PhoneType { get; set; }
    }
}