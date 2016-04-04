using System;
using System.Collections.Generic;
using System.Web.Mvc;
using DataCommon.SiteConfiguration;
using DataLayerCommon.LookupLists;
using DataLayerRetrieval.SiteConfiguration;

namespace ManagementRetrieval.Places
{
    public class SiteConfigurationGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public SiteConfiguration GetSiteConfiguration()
        {
            using (DbSiteConfigurationGet data = new DbSiteConfigurationGet())
            {
                return data.GetSiteConfiguration();
            }
        }

        public List<SelectListItem> GetCompensationTypes()
        {
            using (CompensationTypeLookupList db = new CompensationTypeLookupList())
            {
                return db.LookupList;
            }
        }
    }
}