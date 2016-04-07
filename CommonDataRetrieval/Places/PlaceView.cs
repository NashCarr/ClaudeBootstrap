using System;
using System.Collections.Generic;
using CommonDataRetrieval.Addresses;
using CommonDataRetrieval.Phones;
using DataLayerCommon.People;
using DataLayerCommon.Places;

namespace CommonDataRetrieval.Places
{
    public class PlaceView : IDisposable
    {
        public PlaceView()
        {
            Place = new PlaceBase();
            Phones = new PhoneViewModel();
            Addresses = new AddressViewModel();
        }

        public int FacilityStaffId { get; set; }

        public PlaceBase Place { get; set; }
        public PhoneViewModel Phones { get; set; }
        public List<Contact> Contacts { get; set; }
        public AddressViewModel Addresses { get; set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            Phones.Dispose();
            Addresses.Dispose();

            Phones = null;
            Place = null;
            Addresses = null;
        }
    }
}