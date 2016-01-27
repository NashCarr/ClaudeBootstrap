using System;
using ClaudeData.DataRepository.AdminRepository;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.Admin;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbStaffMemberSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SaveStaffMember(ref StaffMemberView data, ref int personId, ref int facilityStaffId)
        {
            string msg;

            data.Phones.FaxPhone.PhoneType = PhoneType.Fax;
            data.Phones.CellPhone.PhoneType = PhoneType.Cell;
            data.Phones.HomePhone.PhoneType = PhoneType.Home;
            data.Phones.WorkPhone.PhoneType = PhoneType.Work;

            data.Addresses.MailingAddress.AddressType = AddressType.Mailing;
            data.Addresses.ShippingAddress.AddressType = AddressType.Physical;

            PersonData p = new PersonData
            {
                Person = data.StaffUser,
                AddressData = new AddressData(),
                PhoneData = new PhoneData {PhoneSettings = data.Phones.PhoneSettings}
            };

            p.PhoneData.Phones.Add(data.Phones.FaxPhone);
            p.PhoneData.Phones.Add(data.Phones.CellPhone);
            p.PhoneData.Phones.Add(data.Phones.HomePhone);
            p.PhoneData.Phones.Add(data.Phones.WorkPhone);

            p.AddressData.Addresses.Add(data.Addresses.MailingAddress);
            p.AddressData.Addresses.Add(data.Addresses.ShippingAddress);

            using (DbPersonSave db = new DbPersonSave())
            {
                msg = db.SaveStaffUserData(p, ref personId);
            }

            if (!string.IsNullOrEmpty(msg)) return msg;

            FacilityStaff s = new FacilityStaff
            {
                StaffUserId = personId,
                FacilityStaffId = facilityStaffId,
                IsActive = data.StaffUser.IsActive,
                FacilityId = data.StaffUser.PlaceId
            };

            using (DbFacilityStaffSave db = new DbFacilityStaffSave())
            {
                msg = db.AddUpdateRecord(ref s);
            }
            facilityStaffId = s.FacilityStaffId;

            return msg;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}