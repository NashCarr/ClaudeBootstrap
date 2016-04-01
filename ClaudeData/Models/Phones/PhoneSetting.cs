using CommonData.Enums;

namespace DataManagement.Models.Phones
{
    public class PhoneSetting
    {
        public PhoneSetting()
        {
            RecordId = 0;
            MobileCarrier = 0;
            AllowText = false;
            PrimaryPhoneType = PhoneEnums.PhoneType.Cell;
        }

        public int RecordId { get; set; }
        public bool AllowText { get; set; }
        public short MobileCarrier { get; set; }
        public PhoneEnums.PhoneType PrimaryPhoneType { get; set; }
    }
}