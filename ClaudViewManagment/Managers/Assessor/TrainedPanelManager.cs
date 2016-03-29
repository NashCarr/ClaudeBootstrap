using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Assessor;
using ClaudeData.DataRepository.AssessorRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Assessor
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