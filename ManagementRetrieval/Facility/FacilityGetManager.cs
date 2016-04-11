using System;
using System.Collections.Generic;
using CommonDataRetrieval.Facility;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.Facility;
using DataLayerRetrieval.Places;

namespace ManagementRetrieval.Facility
{
    public class FacilityGetManager : IDisposable
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
            using (DbPlaceViewGet db = new DbPlaceViewGet())
            {
                return db.GetFacility(recordId);
            }
        }

        public List<FacilityList> GetFacilityList()
        {
            using (DbFacilityGetList db = new DbFacilityGetList())
            {
                return db.GetList();
            }
        }
    }
}