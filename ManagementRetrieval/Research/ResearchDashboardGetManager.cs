using System;
using System.Collections.Generic;
using System.Linq;
using CommonDataRetrieval.Research;
using DataLayerRetrieval.Research;
using static CommonData.Enums.StudyEnums;

namespace ManagementRetrieval.Research
{
    public class ResearchDashboardGetManager : IDisposable
    {
        public List<ResearchStudy> ActiveList;
        public List<ResearchStudy> CompletedList;
        public List<ResearchStudy> ScreenerList;

        public ResearchDashboardGetManager()
        {
            ActiveList = new List<ResearchStudy>();
            ScreenerList = new List<ResearchStudy>();
            CompletedList = new List<ResearchStudy>();

            List<ResearchStudy> studies;
            using (DbResearchDashboardGet db = new DbResearchDashboardGet())
            {
                studies = db.GetViewModel();
            }

            if (studies == null) return;

            foreach (ResearchStudy item in studies.Where(item => item.Status == StudyStatus.Opened))
            {
                ActiveList.Add(item);
            }
            foreach (ResearchStudy item in studies.Where(item => item.Status == StudyStatus.Opened))
            {
                ScreenerList.Add(item);
            }
            foreach (ResearchStudy item in studies.Where(item => item.Status == StudyStatus.Closed))
            {
                CompletedList.Add(item);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
            ActiveList.Clear();
            ScreenerList.Clear();
            CompletedList.Clear();
        }
    }
}