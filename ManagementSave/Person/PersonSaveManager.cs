using System;
using DataLayerCommon.Addresses;
using DataLayerCommon.People;
using DataLayerCommon.Phones;
using DataLayerSave.Person;
using SaveDataCommon.People;
using SaveDataCommon.Return;

namespace ManagementSave.Person
{
    public class PersonSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SavePerson(PersonSaveModel data)
        {
            PersonData p = new PersonData
            {
                Person = data.Person,
                PhoneData = new PhoneData(),
                AddressData = new AddressData {UseMailingForShipping = data.UseMailingForShipping}
            };

            if (data.PhoneSetting != null)
            {
                p.PhoneData.PhoneSettings = data.PhoneSetting;
            }
            if (data.FaxPhone != null && data.FaxPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.FaxPhone);
            }
            if (data.CellPhone != null && data.CellPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.CellPhone);
            }
            if (data.HomePhone != null && data.HomePhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.HomePhone);
            }
            if (data.WorkPhone != null && data.WorkPhone.PhoneNumber != 0)
            {
                p.PhoneData.Phones.Add(data.WorkPhone);
            }
            if (!string.IsNullOrEmpty(data.MailingAddress?.Address1))
            {
                p.AddressData.Addresses.Add(data.MailingAddress);
            }
            if (!string.IsNullOrEmpty(data.ShippingAddress?.Address1))
            {
                p.AddressData.Addresses.Add(data.ShippingAddress);
            }

            int id = p.Person.PersonId;
            using (DbPersonSave mgr = new DbPersonSave())
            {
                return mgr.SavePerson(p, ref id);
            }
        }
    }
}