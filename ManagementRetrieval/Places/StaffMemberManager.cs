using System;
using CommonDataRetrieval.People;
using DataLayerRetrieval.Person;

namespace ManagementRetrieval.Places
{
    public class StaffMemberManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PersonView GetStaffMember(int recordId)
        {
            using (DbPersonViewGet db = new DbPersonViewGet())
            {
                return db.GetStaffMember(recordId);
            }
        }
    }
}