using System;
using System.Collections.Generic;
using DataLayerReorder;
using DataLayerSave.Administration;
using SaveDataCommon;

namespace ManagementSave.Administration
{
    public class HearAboutUsManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(SaveBase data)
        {
            using (DbHearAboutUsSave db = new DbHearAboutUsSave())
            {
                return db.AddUpdateRecord(data);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.HearAboutUsReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbHearAboutUsSave db = new DbHearAboutUsSave())
            {
                return db.SetInactive(id);
            }
        }
    }
}