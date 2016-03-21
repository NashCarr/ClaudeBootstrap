using System;
using System.Collections.Generic;
using ClaudeCommon.Models.People;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Shared;

namespace ClaudeData.ViewModels
{
    public class PlaceView : IDisposable
    {
        public PlaceView()
        {
            Place = new Place();
            Phones = new PhoneViewModel();
            Addresses = new AddressViewModel();
        }

        public int FacilityStaffId { get; set; }

        public Place Place { get; set; }
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