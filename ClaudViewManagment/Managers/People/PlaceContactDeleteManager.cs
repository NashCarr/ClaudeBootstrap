using System;
using ClaudeData.DataRepository.PersonRepository;

namespace ClaudeViewManagement.Managers.People
{
    public class PlaceContactDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public string DeleteStaffUser(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetStaffUserInactive(id);
            }
        }

        public string DeleteCustomerContact(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetCustomerContactInactive(id);
            }
        }

        public string DeleteOrganizationContact(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetOrganizationContactInactive(id);
            }
        }
    }
}