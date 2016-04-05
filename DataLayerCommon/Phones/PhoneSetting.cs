using static CommonData.Enums.PhoneEnums;

namespace DataLayerCommon.Phones
{
    public class PhoneSetting
    {
        public PhoneSetting()
        {
            RecordId = 0;
            MobileCarrier = 0;
            AllowText = false;
            PrimaryPhoneType = PhoneType.Cell;
        }

        public int RecordId { get; set; }
        public bool AllowText { get; set; }
        public short MobileCarrier { get; set; }
        public PhoneType PrimaryPhoneType { get; set; }
    }
}