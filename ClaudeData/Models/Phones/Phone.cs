using ClaudeData.BaseModels;
using static ClaudeCommon.Enums.CountryEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.Models.Phones
{
    public abstract class Phone : ModelBase
    {
        protected Phone()
        {
            PhoneId = 0;
            PhoneNumber = 0;
            PhoneType = PhoneType.None;
            Country = Country.UnitedStates;
        }

        public int PhoneId { get; set; }
        public Country Country { get; set; }
        public long PhoneNumber { get; set; }
        public PhoneType PhoneType { get; set; }
    }
}