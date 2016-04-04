using System;
using System.Collections.Generic;
using DataLayerRetrieval.Facility;
using ViewDataCommon.Facility;

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
            using (DbFacilityResourceGet data = new DbFacilityResourceGet())
            {
                return data.GetViewModel();
            }
        }

        public List<FacilityResource> GetFacilityList(int facilityId)
        {
            using (DbFacilityResourceGet data = new DbFacilityResourceGet())
            {
                return data.GetFacilityViewModel(facilityId);
            }
        }
    }
}