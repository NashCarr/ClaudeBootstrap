using System;
using System.Collections.Generic;
using CommonDataRetrieval.Facility;
using DataLayerRetrieval.Facility;

namespace ManagementRetrieval.Facility
{
    public class FacilityResourceGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<FacilityResource> GetList()
        {
            using (DbFacilityResourceGet db = new DbFacilityResourceGet())
            {
                return db.GetViewModel();
            }
        }

        public List<FacilityResource> GetFacilityList(int facilityId)
        {
            using (DbFacilityResourceGet db = new DbFacilityResourceGet())
            {
                return db.GetFacilityViewModel(facilityId);
            }
        }
    }
}