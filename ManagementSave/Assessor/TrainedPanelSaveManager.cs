using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Assessor;
using SaveDataCommon.Assessor;
using SaveDataCommon.DisplayReorder;
using SaveDataCommon.Return;

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
            using (DbTrainedPanelSave data = new DbTrainedPanelSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}