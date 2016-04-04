using System;
using System.Collections.Generic;
using DataLayerRetrieval.Assessor;
using ViewDataCommon.Assessor;

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
            using (DbTrainedPanelGet data = new DbTrainedPanelGet())
            {
                return data.GetViewModel();
            }
        }
    }
}