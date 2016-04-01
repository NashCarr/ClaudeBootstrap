using DataManagement.Models.Addresses;
using DataManagement.Models.Phones;

namespace ViewManagement.ViewModels.Shared
{
    public class AddressPhoneSaveModel
    {
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