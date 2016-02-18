using System;
using ClaudeData.Models.Admin;
using ClaudeData.Models.LookupLists;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Shared;

namespace ClaudeData.ViewModels.Settings
{
    public class CustomerView : IDisposable
    {
        public CustomerView()
        {
            Customer = new Place();
            LoginData = new UserLogin();
            Phones = new PhoneViewModel();
            AccessData = new AccessRight();
            Addresses = new AddressViewModel();
        }

        public int FacilityStaffId { get; set; }

        public Place Customer { get; set; }
        public UserLogin LoginData { get; set; }
        public AccessRight AccessData { get; set; }

        public PhoneViewModel Phones { get; set; }
        public AddressViewModel Addresses { get; set; }

        public CountryLookupList CountryList { get; set; }
        public TimeZoneLookupList TimeZoneList { get; set; }
        public PhoneTypeLookupList PhoneTypeList { get; set; }
        //public MobileCarrierLookupList MobileCarrierList { get; set; }

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
            Customer = null;
            LoginData = null;
            Addresses = null;
            AccessData = null;
            TimeZoneList = null;

            CountryList?.LookupList.Clear();
            TimeZoneList?.LookupList.Clear();
            PhoneTypeList?.LookupList.Clear();
            //MobileCarrierList?.LookupList.Clear();

            CountryList = null;
            TimeZoneList = null;
            PhoneTypeList = null;
            //MobileCarrierList = null;
        }
    }
}