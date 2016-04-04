using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Place;
using DataRetrievalCommon.Places;
using SaveDataCommon;

namespace ViewManagement.Managers.Facility
{
    public class FacilityManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PlaceView GetFacility(int recordId)
        {
            using (DbPlaceViewGet data = new DbPlaceViewGet())
            {
                return data.GetFacility(recordId);
            }
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
            using (DbPlaceSetInactive data = new DbPlaceSetInactive())
            {
                return data.SetFacilityInactive(id);
            }
        }
    }
}