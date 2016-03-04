using System;
using System.Collections.Generic;
using ClaudeCommon.Models;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Shared;

namespace ClaudeData.ViewModels.Settings
{
    public class CustomerView : IDisposable
    {
        public CustomerView()
        {
            Place = new Place();
            Phones = new PhoneViewModel();
            Contacts = new List<Contact>();
            Addresses = new AddressViewModel();
        }

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
            Phones?.Dispose();
            Contacts?.Clear();
            Addresses?.Dispose();

            Place = null;
            Phones = null;
            Contacts = null;
            Addresses = null;
        }
    }
}