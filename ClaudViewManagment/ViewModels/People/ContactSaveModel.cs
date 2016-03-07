using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;

namespace ClaudeViewManagement.ViewModels.People
{
    public class ContactSaveModel
    {
        public Person Person { get; set; }
        public PhoneSetting PhoneSetting { get; set; }
        public PhoneAssociation FaxPhone { get; set; }
        public PhoneAssociation CellPhone { get; set; }
        public PhoneAssociation HomePhone { get; set; }
        public PhoneAssociation WorkPhone { get; set; }
        public bool UseMailingForShipping { get; set; }
        public AddressAssociation MailingAddress { get; set; }
        public AddressAssociation ShippingAddress { get; set; }
    }
}