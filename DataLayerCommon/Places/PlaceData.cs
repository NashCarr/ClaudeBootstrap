using System.Collections.Generic;
using DataLayerCommon.Addresses;
using DataLayerCommon.People;
using DataLayerCommon.Phones;

namespace DataLayerCommon.Places
{
    public class PlaceData
    {
        public PlaceData()
        {
            Place = new Place();
        }

        public Place Place { get; set; }
        public PhoneData PhoneData { get; set; }
        public List<Contact> Contacts { get; set; }
        public AddressData AddressData { get; set; }
    }
}