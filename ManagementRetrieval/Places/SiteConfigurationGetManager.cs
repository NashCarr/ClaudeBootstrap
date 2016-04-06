using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonDataRetrieval.SiteConfiguration;
using DataLayerRetrieval.Lookup;
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

        public SiteConfigurationGet GetSiteConfiguration()
        {
            using (DbSiteConfigurationGet db = new DbSiteConfigurationGet())
            {
                return db.GetSiteConfiguration();
            }
        }

        public List<SelectListItem> GetCompensationTypes()
        {
            using (LuCompensationTypeLookup lu = new LuCompensationTypeLookup())
            {
                return lu.LookupList;
            }
        }
    }
}