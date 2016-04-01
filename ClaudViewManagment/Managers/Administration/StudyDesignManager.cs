using System;
using System.Collections.Generic;
using CommonData.BaseModels;
using CommonData.BaseModels.Returns;
using CommonData.Models.Administration;
using DataManagement.DataRepository.AdministrationRepository;
using DataManagement.DataRepository.ReorderRepository;

namespace ViewManagement.Managers.Administration
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