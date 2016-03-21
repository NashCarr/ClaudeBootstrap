using System;
using ClaudeCommon.Models.SiteConfiguration;
using ClaudeData.DataRepository.SettingsRepository;

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
            using (DbSiteConfigurationGet data = new DbSiteConfigurationGet())
            {
                return data.GetSiteConfiguration();
            }
        }
    }
}