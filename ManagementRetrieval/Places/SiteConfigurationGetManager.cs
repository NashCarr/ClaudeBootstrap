using System;
using CommonDataRetrieval.SiteConfiguration;
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
    }
}