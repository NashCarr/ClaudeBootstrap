using System;
using System.Collections.Generic;
using System.Web.Mvc;
using CommonData.Models.SiteConfiguration;
using DataManagement.DataRepository.SiteConfiguration;
using DataManagement.Models.LookupLists;
using ManagementLookup.LookupLists;

namespace ViewManagement.Managers.Places
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