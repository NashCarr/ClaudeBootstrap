using System;
using ClaudeCommon.Enums;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using ClaudeData.ViewModels;

namespace ClaudeData.DataRepository.PeopleRepository
{
    public class DbAssessorSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public string SaveAssessor(ref AssessorView data, ref int personId)
        {
            string msg;

            data.Phones.FaxPhone.PhoneType = PhoneEnums.PhoneType.Fax;
            data.Phones.CellPhone.PhoneType = PhoneEnums.PhoneType.Cell;
            data.Phones.HomePhone.PhoneType = PhoneEnums.PhoneType.Home;
            data.Phones.WorkPhone.PhoneType = PhoneEnums.PhoneType.Work;

            data.Addresses.MailingAddress.AddressType = AddressEnums.AddressType.Mailing;
            data.Addresses.ShippingAddress.AddressType = AddressEnums.AddressType.Physical;

            PersonData p = new PersonData
            {
                Person = data.Assessor,
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
                msg = db.SavePerson(p, ref personId).ErrMsg;
            }

            return msg;
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}