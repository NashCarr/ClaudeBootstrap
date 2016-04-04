using System;
using DataLayerRetrieval.Person;
using DataRetrievalCommon.People;

namespace ViewManagement.Managers.People
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
            using (DbPersonViewGet data = new DbPersonViewGet())
            {
                return data.GetStaffMember(recordId);
            }
        }
    }
}