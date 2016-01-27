using System;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using ClaudeData.ViewModels.Settings;
using static ClaudeCommon.Enums.AddressEnums;
using static ClaudeCommon.Enums.PhoneEnums;

namespace ClaudeData.DataRepository.SettingsRepository
{
    public class DbCustomerContactSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SaveCustomerContact(ref CustomerContactView data, ref int personId)
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
                Person = data.CustomerContact,
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
                msg = db.SaveCustomerContactData(p, ref personId);
            }

            return msg;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}