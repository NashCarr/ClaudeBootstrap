using System;
using DataLayerSave.Person;

namespace ManagementSave.Person
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

        public string DeleteStaffMember(int id)
        {
            using (DbPersonSetInactive data = new DbPersonSetInactive())
            {
                return data.SetStaffMemberInactive(id);
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