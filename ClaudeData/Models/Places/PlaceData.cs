using System.Collections.Generic;
using CommonData.Models.People;
using DataManagement.Models.Addresses;
using DataManagement.Models.Phones;

namespace DataManagement.Models.Places
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