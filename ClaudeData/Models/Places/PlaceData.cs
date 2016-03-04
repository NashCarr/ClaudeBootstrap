using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;

namespace ClaudeData.Models.Places
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