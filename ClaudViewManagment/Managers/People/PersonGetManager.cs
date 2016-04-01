using System;
using DataManagement.DataRepository.PersonRepository;
using DataManagement.ViewModels;

namespace ViewManagement.Managers.People
{
    public class PersonGetManager : IDisposable
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