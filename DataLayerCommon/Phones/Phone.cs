using DataLayerCommon.BaseModels;
using static DataLayerCommon.Enums.CountryEnums;
using static DataLayerCommon.Enums.PhoneEnums;

namespace DataLayerCommon.Phones
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