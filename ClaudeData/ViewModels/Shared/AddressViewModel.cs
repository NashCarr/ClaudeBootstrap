using System;
using DataManagement.Models.Addresses;

namespace DataManagement.ViewModels.Shared
{
    public class AddressViewModel : IDisposable
    {
        public AddressViewModel()
        {
            MailingAddress = new AddressAssociation();
            ShippingAddress = new AddressAssociation();
        }

        public AddressAssociation MailingAddress { get; set; }
        public AddressAssociation ShippingAddress { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            MailingAddress = null;
            ShippingAddress = null;
        }
    }
}