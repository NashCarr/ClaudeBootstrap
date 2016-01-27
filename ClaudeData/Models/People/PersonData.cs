using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;

namespace ClaudeData.Models.People
{
    public class PersonData
    {
        public PersonData()
        {
            Person = new Person();
        }

        public Person Person { get; set; }
        public PhoneData PhoneData { get; set; }
        public AddressData AddressData { get; set; }
    }
}