using ClaudeCommon.Models;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Phones;
using Place = ClaudeData.Models.Places.Place;

namespace ClaudeViewManagement.ViewModels.Places
{
    public class PlaceSaveModel
    {
        public Place Place { get; set; }
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