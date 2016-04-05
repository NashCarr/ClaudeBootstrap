using System;
using CommonDataRetrieval.Addresses;
using CommonDataRetrieval.Phones;
using DataLayerCommon.People;

namespace CommonDataRetrieval.People
{
    public class PersonView : IDisposable
    {
        public PersonView()
        {
            Person = new Person();
            Phones = new PhoneViewModel();
            Addresses = new AddressViewModel();
        }

        public Person Person { get; set; }
        public PhoneViewModel Phones { get; set; }
        public AddressViewModel Addresses { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            Phones?.Dispose();
            Addresses?.Dispose();

            Person = null;
            Phones = null;
            Addresses = null;
        }
    }
}