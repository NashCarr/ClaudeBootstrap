using System;
using System.Collections.Generic;
using ClaudeCommon.BaseModels;
using ClaudeCommon.BaseModels.Returns;
using ClaudeCommon.Models.Administration;
using ClaudeData.DataRepository.AdministrationRepository;
using ClaudeData.DataRepository.ReorderRepository;

namespace ClaudeViewManagement.Managers.Administration
{
    public class StudyDesignManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public List<StudyDesign> GetList()
        {
            using (DbStudyDesignGet data = new DbStudyDesignGet())
            {
                return data.GetViewModel();
            }
        }

        public ReturnBase SaveRecord(StudyDesign entity)
        {
            using (DbStudyDesignSave data = new DbStudyDesignSave())
            {
                return data.AddUpdateRecord(entity);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.StudyDesignReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int recordId)
        {
            using (DbStudyDesignSave data = new DbStudyDesignSave())
            {
                return data.SetInactive(recordId);
            }
        }
    }
}