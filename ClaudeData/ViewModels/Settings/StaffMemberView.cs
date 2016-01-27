using System;
using ClaudeData.Models.Admin;
using ClaudeData.Models.LookupLists;
using ClaudeData.Models.People;
using ClaudeData.ViewModels.Shared;

namespace ClaudeData.ViewModels.Settings
{
    public class StaffMemberView : IDisposable
    {
        public StaffMemberView()
        {
            StaffUser = new Person();
            LoginData = new UserLogin();
            Phones = new PhoneViewModel();
            AccessData = new AccessRight();
            Addresses = new AddressViewModel();
            FacilityList = new PlaceLookupList();
            LoginActivityData = new StaffUserActivity();
        }

        public int FacilityStaffId { get; set; }

        public Person StaffUser { get; set; }
        public UserLogin LoginData { get; set; }
        public AccessRight AccessData { get; set; }
        public StaffUserActivity LoginActivityData { get; set; }

        public PhoneViewModel Phones { get; set; }
        public AddressViewModel Addresses { get; set; }

        public PlaceLookupList FacilityList { get; set; }
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
            StaffUser = null;
            LoginData = null;
            Addresses = null;
            AccessData = null;
            FacilityList = null;
            LoginActivityData = null;

            CountryList?.LookupList.Clear();
            FacilityList?.LookupList.Clear();
            TimeZoneList?.LookupList.Clear();
            PhoneTypeList?.LookupList.Clear();
            MobileCarrierList?.LookupList.Clear();

            CountryList = null;
            FacilityList = null;
            PhoneTypeList = null;
            MobileCarrierList = null;
        }
    }
}