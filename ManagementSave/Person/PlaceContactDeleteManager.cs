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
            using (DbPersonSetInactive db = new DbPersonSetInactive())
            {
                return db.SetStaffMemberInactive(id);
            }
        }

        public string DeleteCustomerContact(int id)
        {
            using (DbPersonSetInactive db = new DbPersonSetInactive())
            {
                return db.SetCustomerContactInactive(id);
            }
        }

        public string DeleteOrganizationContact(int id)
        {
            using (DbPersonSetInactive db = new DbPersonSetInactive())
            {
                return db.SetOrganizationContactInactive(id);
            }
        }
    }
}