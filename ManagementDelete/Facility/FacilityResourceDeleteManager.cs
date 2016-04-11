using System;
using CommonDataReturn;
using DataLayerDelete.Facility;

namespace ManagementDelete.Facility
{
    public class FacilityResourceDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbFacilityResourceDelete db = new DbFacilityResourceDelete())
            {
                return db.SetInactive(id);
            }
        }
    }
}