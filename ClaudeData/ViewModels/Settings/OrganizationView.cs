using System;
using ClaudeData.Models.Admin;
using ClaudeData.Models.LookupLists;
using ClaudeData.Models.Places;
using ClaudeData.ViewModels.Shared;

namespace ClaudeData.ViewModels.Settings
{
    public class OrganizationView : IDisposable
    {
        public OrganizationView()
        {
            Organization = new Place();
            LoginData = new UserLogin();
            Phones = new PhoneViewModel();
            AccessData = new AccessRight();
            Addresses = new AddressViewModel();
        }

        public int FacilityStaffId { get; set; }

        public Place Organization { get; set; }
        public UserLogin LoginData { get; set; }
        public AccessRight AccessData { get; set; }

        public PhoneViewModel Phones { get; set; }
        public AddressViewModel Addresses { get; set; }

        public CountryLookupList CountryList { get; set; }
        public TimeZoneLookupList TimeZoneList { get; set; }
        public PhoneTypeLookupList PhoneTypeList { get; set; }
        public MobileCarrierLookupList MobileCarrierList { get; set; }

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
            LoginData = null;
            Addresses = null;
            AccessData = null;
            TimeZoneList = null;
            Organization = null;

            CountryList?.LookupList.Clear();
            TimeZoneList?.LookupList.Clear();
            PhoneTypeList?.LookupList.Clear();
            MobileCarrierList?.LookupList.Clear();

            CountryList = null;
            TimeZoneList = null;
            PhoneTypeList = null;
            MobileCarrierList = null;
        }
    }
}