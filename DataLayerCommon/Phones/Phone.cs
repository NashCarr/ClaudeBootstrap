using static CommonData.Enums.CountryEnums;
using static CommonData.Enums.PhoneEnums;

namespace DataLayerCommon.Phones
{
    public abstract class Phone
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