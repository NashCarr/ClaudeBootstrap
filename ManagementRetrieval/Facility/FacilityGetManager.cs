using System;
using DataLayerRetrieval.Place;
using DataRetrievalCommon.Places;

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
            using (DbPlaceViewGet data = new DbPlaceViewGet())
            {
                return data.GetFacility(recordId);
            }
        }
    }
}