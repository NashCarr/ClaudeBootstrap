using System;
using DataLayerDelete.Person;

namespace ManagementDelete.Person
{
    public class PersonDeleteManager : IDisposable
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
            using (DbPersonDelete db = new DbPersonDelete())
            {
                return db.SetStaffMemberInactive(id);
            }
        }

        public string DeleteCustomerContact(int id)
        {
            using (DbPersonDelete db = new DbPersonDelete())
            {
                return db.SetCustomerContactInactive(id);
            }
        }

        public string DeleteOrganizationContact(int id)
        {
            using (DbPersonDelete db = new DbPersonDelete())
            {
                return db.SetOrganizationContactInactive(id);
            }
        }
    }
}