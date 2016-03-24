using System;
using System.Collections.Generic;
using ClaudeData.DataRepository.AddressRepository;
using ClaudeData.Models.Addresses;
using ClaudeData.Models.People;
using static ClaudeCommon.Enums.PersonEnums;

namespace ClaudeData.DataRepository.PersonRepository
{
    public class DbPersonAddressSave : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected internal string SaveAssessorAddress(int personId, AddressAssociation data)
        {
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePersonAddress(personId, (byte) PersonType.Assessor, data);
            }
        }

        protected internal string SaveCustomerContactAddress(int personId, AddressAssociation data)
        {
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePersonAddress(personId, (byte) PersonType.CustomerContact, data);
            }
        }

        protected internal string SaveStaffMemberAddress(int personId, AddressAssociation data)
        {
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePersonAddress(personId, (byte) PersonType.StaffMember, data);
            }
        }

        protected internal string SaveOrganizationContactAddress(int personId, AddressAssociation data)
        {
            using (DbAddressAssociationSave db = new DbAddressAssociationSave())
            {
                return db.SavePersonAddress(personId, (byte) PersonType.OrganizationContact, data);
            }
        }

        protected internal string SaveAssessorAddresses(int personId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            foreach (AddressAssociation item in data)
            {
                msg = SaveAssessorAddress(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveCustomerContactAddresses(int personId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            foreach (AddressAssociation item in data)
            {
                msg = SaveCustomerContactAddress(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveStaffMemberAddresses(int personId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            foreach (AddressAssociation item in data)
            {
                msg = SaveStaffMemberAddress(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SaveOrganizationContactAddresses(int personId, List<AddressAssociation> data)
        {
            string msg = string.Empty;
            foreach (AddressAssociation item in data)
            {
                msg = SaveOrganizationContactAddress(personId, item);
                if (msg.Length == 0) continue;
                break;
            }
            return msg;
        }

        protected internal string SavePersonAddresses(PersonData data)
        {
            switch (data.Person.PersonType)
            {
                case PersonType.Assessor:
                    return SaveAssessorAddresses(data.Person.PersonId, data.AddressData.Addresses);
                case PersonType.StaffMember:
                    return SaveStaffMemberAddresses(data.Person.PersonId, data.AddressData.Addresses);
                case PersonType.CustomerContact:
                    return SaveCustomerContactAddresses(data.Person.PersonId, data.AddressData.Addresses);
                case PersonType.OrganizationContact:
                    return SaveOrganizationContactAddresses(data.Person.PersonId, data.AddressData.Addresses);
                default:
                    return "Person Type Undetermined";
            }
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }
    }
}