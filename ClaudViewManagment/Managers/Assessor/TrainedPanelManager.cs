using System;
using System.Collections.Generic;
using CommonData.Models.Assessor;
using DataManagement.DataRepository.AssessorRepository;
using DataManagement.DataRepository.ReorderRepository;
using SaveDataCommon;

namespace ViewManagement.Managers.Assessor
{
    public class TrainedPanelManager : IDisposable
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

        public ReturnBase SaveRecord(TrainedPanel entity)
        {
            using (DbTrainedPanelSave data = new DbTrainedPanelSave())
            {
                return data.AddUpdateRecord(entity);
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