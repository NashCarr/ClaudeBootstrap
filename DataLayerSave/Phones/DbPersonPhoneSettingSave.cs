using System;
using CommonData.Enums;
using DataLayerCommon.People;
using DataLayerCommon.Phones;

namespace DataLayerSave.Phones
{
    public class DbPersonPhoneSettingSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveStaffMemberPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonEnums.PersonType.StaffMember, data);
            }
        }

        protected internal string SaveAssessorPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonEnums.PersonType.Assessor, data);
            }
        }

        protected internal string SaveCustomerContactPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonEnums.PersonType.CustomerContact, data);
            }
        }

        protected internal string SaveOrganizationContactPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonEnums.PersonType.OrganizationContact, data);
            }
        }

        protected internal string SavePersonPhoneSetting(PersonData data)
        {
            if (data.PhoneData == null) return string.Empty;
            switch (data.Person.PersonType)
            {
                case PersonEnums.PersonType.StaffMember:
                    return SaveStaffMemberPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonEnums.PersonType.Assessor:
                    return SaveAssessorPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonEnums.PersonType.CustomerContact:
                    return SaveCustomerContactPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonEnums.PersonType.OrganizationContact:
                    return SaveOrganizationContactPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonEnums.PersonType.None:
                    return "Person Type Undetermined";
                default:
                    return "Person Type Undetermined";
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}