using System;
using DataLayerRetrieval.Place;
using DataRetrievalCommon.Places;

namespace ManagementRetrieval.Places
{
    public class OrganizationGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public PlaceView GetOrganization(int recordId)
        {
            using (DbPlaceViewGet data = new DbPlaceViewGet())
            {
                return data.GetOrganization(recordId);
            }
        }
    }
}