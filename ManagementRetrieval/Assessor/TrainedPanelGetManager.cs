using System;
using System.Collections.Generic;
using CommonDataRetrieval.Assessor;
using DataLayerRetrieval.Assessor;

namespace ManagementRetrieval.Assessor
{
    public class TrainedPanelGetManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<TrainedPanel> GetList()
        {
            using (DbTrainedPanelGet db = new DbTrainedPanelGet())
            {
                return db.GetViewModel();
            }
        }
    }
}