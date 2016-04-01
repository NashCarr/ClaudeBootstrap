using System.Collections.Generic;
using System.Linq;
using CommonData.Enums;

namespace DataManagement.Models.Addresses
{
    public class AddressData
    {
        public AddressData()
        {
            UseMailingForShipping = true;
            Addresses = new List<AddressAssociation>();
        }

        public bool UseMailingForShipping { get; set; }
        public List<AddressAssociation> Addresses { get; set; }

        public AddressAssociation MailingAddress
            => Addresses.SingleOrDefault(e => e.AddressType == AddressEnums.AddressType.Mailing);

        public AddressAssociation PhysicalAddress
            => Addresses.SingleOrDefault(e => e.AddressType == AddressEnums.AddressType.Physical);
    }
}