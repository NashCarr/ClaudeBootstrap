using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Facility;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.Facility;
using SaveDataCommon.Return;

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

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.FacilityResourceReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbFacilityResourceSave db = new DbFacilityResourceSave())
            {
                return db.SetInactive(id);
            }
        }
    }
}