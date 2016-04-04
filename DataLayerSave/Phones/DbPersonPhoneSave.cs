using System;
using System.Collections.Generic;
using CommonData.Enums;
using DataLayerCommon.People;
using DataLayerCommon.Phones;

namespace DataLayerSave.Phones
{
    public class DbPersonPhoneSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveAssessorPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonEnums.PersonType.Assessor, data);
            }
        }

        protected internal string SaveStaffMemberPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonEnums.PersonType.StaffMember, data);
            }
        }

        protected internal string SaveCustomerContactPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonEnums.PersonType.CustomerContact, data);
            }
        }

        protected internal string SaveOrganizationContactPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonEnums.PersonType.OrganizationContact, data);
            }
        }

        protected internal string SaveAssessorPhones(int personId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            foreach (PhoneAssociation item in data)
            {
                msg = SaveAssessorPhone(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveStaffMemberPhones(int personId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            foreach (PhoneAssociation item in data)
            {
                msg = SaveStaffMemberPhone(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveCustomerContactPhones(int personId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            foreach (PhoneAssociation item in data)
            {
                msg = SaveCustomerContactPhone(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveOrganizationContactPhones(int personId, List<PhoneAssociation> data)
        {
            string msg = string.Empty;
            foreach (PhoneAssociation item in data)
            {
                msg = SaveOrganizationContactPhone(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SavePersonPhones(PersonData data)
        {
            switch (data.Person.PersonType)
            {
                case PersonEnums.PersonType.Assessor:
                    return SaveAssessorPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonEnums.PersonType.StaffMember:
                    return SaveStaffMemberPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonEnums.PersonType.CustomerContact:
                    return SaveCustomerContactPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonEnums.PersonType.OrganizationContact:
                    return SaveOrganizationContactPhones(data.Person.PersonId, data.PhoneData.Phones);
                default:
                    return "Person Type Undetermined";
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}