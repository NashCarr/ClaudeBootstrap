using System;
using CommonDataRetrieval.Places;
using DataLayerRetrieval.Places;

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
            using (DbPlaceViewGet db = new DbPlaceViewGet())
            {
                return db.GetOrganization(recordId);
            }
        }
    }
}