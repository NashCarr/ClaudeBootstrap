using System;
using System.Collections.Generic;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.People;

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

        public List<StaffMember> GetList()
        {
            using (DbStaffMemberListGet db = new DbStaffMemberListGet())
            {
                return db.GetList();
            }
        }
    }
}