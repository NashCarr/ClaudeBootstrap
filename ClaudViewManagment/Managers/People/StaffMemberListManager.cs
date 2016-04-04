using System;
using System.Collections.Generic;
using CommonData.Models.Facility;
using DataLayerRetrieval.People;

namespace ViewManagement.Managers.People
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