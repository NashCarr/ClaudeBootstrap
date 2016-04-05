using System;
using System.Collections.Generic;
using CommonDataSave.Assessor;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
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

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.TrainedPanelReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbTrainedPanelSave db = new DbTrainedPanelSave())
            {
                return db.SetInactive(recordId);
            }
        }
    }
}