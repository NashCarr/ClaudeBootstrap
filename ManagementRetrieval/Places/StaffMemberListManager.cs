using System;
using System.Collections.Generic;
using DataLayerRetrieval.People;
using ViewDataCommon.Facility;

namespace ManagementRetrieval.Places
{
    public class StaffMemberListManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<StaffMemberList> GetList()
        {
            using (DbStaffMemberListGet data = new DbStaffMemberListGet())
            {
                return data.GetList();
            }
        }
    }
}