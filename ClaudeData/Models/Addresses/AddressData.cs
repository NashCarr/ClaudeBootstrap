﻿using System.Collections.Generic;
using System.Linq;
using static ClaudeCommon.Enums.AddressEnums;

namespace ClaudeData.Models.Addresses
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
            => Addresses.SingleOrDefault(e => e.AddressType == AddressType.Mailing);

        public AddressAssociation PhysicalAddress
            => Addresses.SingleOrDefault(e => e.AddressType == AddressType.Physical);
    }
}