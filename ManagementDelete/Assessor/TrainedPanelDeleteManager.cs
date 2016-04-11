using System;
using CommonDataReturn;
using DataLayerDelete.Assessor;

namespace ManagementDelete.Assessor
{
    public class TrainedPanelDeleteManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbTrainedPanelDelete db = new DbTrainedPanelDelete())
            {
                return db.SetInactive(recordId);
            }
        }
    }
}