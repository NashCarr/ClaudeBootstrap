using System;
using DataLayerCommon.People;
using DataLayerCommon.Phones;
using static CommonData.Enums.PersonEnums;

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
                return db.SavePersonPhoneSetting(personId, (byte) PersonType.StaffMember, data);
            }
        }

        protected internal string SaveAssessorPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonType.Assessor, data);
            }
        }

        protected internal string SaveCustomerContactPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonType.CustomerContact, data);
            }
        }

        protected internal string SaveOrganizationContactPhoneSetting(int personId, PhoneSetting data)
        {
            if (data == null) return string.Empty;
            using (DbPhoneSettingSave db = new DbPhoneSettingSave())
            {
                return db.SavePersonPhoneSetting(personId, (byte) PersonType.OrganizationContact, data);
            }
        }

        protected internal string SavePersonPhoneSetting(PersonData data)
        {
            if (data.PhoneData == null) return string.Empty;
            switch (data.Person.PersonType)
            {
                case PersonType.StaffMember:
                    return SaveStaffMemberPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonType.Assessor:
                    return SaveAssessorPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonType.CustomerContact:
                    return SaveCustomerContactPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonType.OrganizationContact:
                    return SaveOrganizationContactPhoneSetting(data.Person.PersonId, data.PhoneData.PhoneSettings);
                case PersonType.None:
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