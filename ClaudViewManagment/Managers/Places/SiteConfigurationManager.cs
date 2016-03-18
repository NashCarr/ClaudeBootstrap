using System;
using ClaudeData.Models.SiteConfiguration;

namespace ClaudeViewManagement.Managers.Places
{
    public class SiteConfigurationManager : IDisposable
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
            //using (DbPlacesGetActive data = new DbPlacesGetActive())
            //{
            //    return data.GetActive();
            //}
            return null;
        }
    }
}