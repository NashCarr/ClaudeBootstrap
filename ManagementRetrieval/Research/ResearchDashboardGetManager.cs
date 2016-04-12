using System;
using System.Collections.Generic;
using CommonDataRetrieval.Administration;
using CommonDataRetrieval.Research;
using DataLayerRetrieval.Administration;
using DataLayerRetrieval.Research;

namespace ManagementRetrieval.Research
{
    public class ResearchDashboardGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<ResearchDashboard> GetResearchDashboardList()
        {
            using (DbResearchDashboardGet db = new DbResearchDashboardGet())
            {
                return db.GetViewModel();
            }
        }
    }
}