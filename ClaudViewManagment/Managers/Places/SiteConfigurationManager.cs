using System;
using System.Collections.Generic;
using System.Web.Mvc;
using ClaudeCommon.Models.SiteConfiguration;
using ClaudeData.DataRepository.SiteConfiguration;
using ClaudeData.Models.LookupLists;

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

        public List<SelectListItem> GetCompensationTypes()
        {
            using (CompensationTypeLookupList db = new CompensationTypeLookupList())
            {
                return db.LookupList;
            }
        }
    }
}