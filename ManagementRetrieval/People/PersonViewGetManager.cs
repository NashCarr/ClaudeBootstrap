using System;
using CommonDataRetrieval.People;
using DataLayerRetrieval.Person;

namespace ManagementRetrieval.People
{
    public class PersonViewGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PersonView GetCustomerContact(int recordId)
        {
            using (DbPersonViewGet db = new DbPersonViewGet())
            {
                return db.GetCustomerContact(recordId);
            }
        }

        public PersonView GetOrganizationContact(int recordId)
        {
            using (DbPersonViewGet db = new DbPersonViewGet())
            {
                return db.GetOrganizationContact(recordId);
            }
        }

        public PersonView GetStaffMember(int recordId)
        {
            using (DbPersonViewGet db = new DbPersonViewGet())
            {
                return db.GetStaffMember(recordId);
            }
        }

        public PersonView GetAssessor(int recordId)
        {
            using (DbPersonViewGet db = new DbPersonViewGet())
            {
                return db.GetStaffMember(recordId);
            }
        }
    }
}