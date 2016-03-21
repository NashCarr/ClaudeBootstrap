using System;
using ClaudeData.DataRepository.PersonRepository;
using ClaudeData.ViewModels;

namespace ClaudeViewManagement.Managers.People
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

        public PersonView GetStaffUser(int recordId)
        {
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetStaffMember(recordId);
            }
        }
    }
}