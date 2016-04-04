using System.Collections.Generic;
using System.Linq;
using static DataLayerCommon.Enums.PhoneEnums;

namespace DataLayerCommon.Phones
{
    public class PhoneData
    {
        public PhoneData()
        {
            PhoneSettings = new PhoneSetting();
            Phones = new List<PhoneAssociation>();
        }

        public PhoneSetting PhoneSettings { get; set; }
        public List<PhoneAssociation> Phones { get; set; }

        public PhoneAssociation FaxPhone => Phones.SingleOrDefault(e => e.PhoneType == PhoneType.Fax);
        public PhoneAssociation CellPhone => Phones.SingleOrDefault(e => e.PhoneType == PhoneType.Cell);
        public PhoneAssociation HomePhone => Phones.SingleOrDefault(e => e.PhoneType == PhoneType.Home);
        public PhoneAssociation WorkPhone => Phones.SingleOrDefault(e => e.PhoneType == PhoneType.Work);
    }
}