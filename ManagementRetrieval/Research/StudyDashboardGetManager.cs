using System;
using System.Collections.Generic;
using CommonDataRetrieval.Research;
using DataLayerRetrieval.Research;

namespace ManagementRetrieval.Research
{
    public class StudyDashboardGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<StudyDashboard> GetStudyDashboardList()
        {
            using (DbStudyDashboardGet db = new DbStudyDashboardGet())
            {
                return db.GetViewModel();
            }
        }
    }
}