using System;
using CommonDataReturn;
using CommonDataSave.Facility;
using DataLayerSave.Facility;

namespace ManagementSave.Facility
{
    public class FacilityResourceSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(FacilityResourceSave entity)
        {
            using (DbFacilityResourceSave db = new DbFacilityResourceSave())
            {
                return db.AddUpdateRecord(entity);
            }
        }
   }
}