using System;
using CommonDataReturn;
using CommonDataSave.Assessor;
using DataLayerSave.Assessor;

namespace ManagementSave.Assessor
{
    public class TrainedPanelSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(TrainedPanelSave data)
        {
            using (DbTrainedPanelSave db = new DbTrainedPanelSave())
            {
                return db.AddUpdateRecord(data);
            }
        }
    }
}