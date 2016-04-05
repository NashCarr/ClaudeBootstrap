using System;
using System.Collections.Generic;
using CommonDataSave.Administration;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
using DataLayerSave.Administration;

namespace ManagementSave.Administration
{
    public class StudyDesignSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(StudyDesignSave data)
        {
            using (DbStudyDesignSave db = new DbStudyDesignSave())
            {
                return db.AddUpdateRecord(data);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.StudyDesignReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbStudyDesignSave db = new DbStudyDesignSave())
            {
                return db.SetInactive(id);
            }
        }
    }
}