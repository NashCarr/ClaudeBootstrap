using System;
using System.Collections.Generic;
using CommonDataSave.Administration;
using CommonDataSave.DisplayReorder;
using CommonDataSave.Return;
using DataLayerReorder;
using DataLayerSave.Administration;

namespace ManagementSave.Administration
{
    public class TestTypeSaveManager : IDisposable
    {
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool iAmBeingCalledFromDisposeAndNotFinalize)
        {
        }

        public ReturnBase SaveRecord(TestTypeSave data)
        {
            using (DbTestTypeSave db = new DbTestTypeSave())
            {
                return db.AddUpdateRecord(data);
            }
        }

        public void SaveDisplayReorder(List<DisplayReorder> data)
        {
            using (DbReorderSave db = new DbReorderSave())
            {
                db.TestTypeReorderSave(data);
            }
        }

        public ReturnBase DeleteRecord(int id)
        {
            using (DbTestTypeSave db = new DbTestTypeSave())
            {
                return db.SetInactive(id);
            }
        }
    }
}