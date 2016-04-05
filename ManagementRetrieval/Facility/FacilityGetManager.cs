using System;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.Place;

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
    }
}