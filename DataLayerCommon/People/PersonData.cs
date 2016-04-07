using DataLayerCommon.Addresses;
using DataLayerCommon.Phones;

namespace DataLayerCommon.People
{
    public class PersonData
    {
        public PersonData()
        {
            Person = new PersonBase();
        }

        public PersonBase Person { get; set; }
        public PhoneData PhoneData { get; set; }
        public AddressData AddressData { get; set; }
    }
}