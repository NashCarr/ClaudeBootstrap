using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.PhoneRepository;
using ClaudeData.Models.People;
using ClaudeData.Models.Phones;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PersonRepository
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
                return db.SavePersonPhone(personId, (byte) PersonType.Assessor, data);
            }
        }

        protected internal string SaveStaffMemberPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonType.StaffMember, data);
            }
        }

        protected internal string SaveCustomerContactPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonType.CustomerContact, data);
            }
        }

        protected internal string SaveOrganizationContactPhone(int personId, PhoneAssociation data)
        {
            using (DbPhoneAssociationSave db = new DbPhoneAssociationSave())
            {
                return db.SavePersonPhone(personId, (byte) PersonType.OrganizationContact, data);
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
                case PersonType.Assessor:
                    return SaveAssessorPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonType.StaffMember:
                    return SaveStaffMemberPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonType.CustomerContact:
                    return SaveCustomerContactPhones(data.Person.PersonId, data.PhoneData.Phones);
                case PersonType.OrganizationContact:
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