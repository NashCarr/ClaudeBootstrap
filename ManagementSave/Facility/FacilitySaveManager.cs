using System;
using System.Collections.Generic;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
using DataLayerSave.Place;

namespace ManagementSave.Facility
{
    public class FacilitySaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public void SaveDisplayOrder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.FacilityReorderSave(data);
            }
        }

        public ReturnBase DeleteFacility(int id)
        {
            using (DbPlaceSetInactive db = new DbPlaceSetInactive())
            {
                return db.SetFacilityInactive(id);
            }
        }
    }
}