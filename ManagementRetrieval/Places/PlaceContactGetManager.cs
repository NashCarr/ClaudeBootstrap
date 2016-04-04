using System;
using DataLayerRetrieval.Person;
using DataRetrievalCommon.People;

namespace ManagementRetrieval.Places
{
    public class PlaceContactGetManager : IDisposable
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
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetCustomerContact(recordId);
            }
        }

        public PersonView GetOrganizationContact(int recordId)
        {
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetOrganizationContact(recordId);
            }
        }

        public PersonView GetStaffMember(int recordId)
        {
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetStaffMember(recordId);
            }
        }
    }
}